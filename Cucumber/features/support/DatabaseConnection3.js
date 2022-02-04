const sql = require('mssql');
const TokenSecret = require('./tokenSecret');
const defaultValues = require('./defaultValues');

const sqlConfig = {
  user: TokenSecret.userDB,
  password:TokenSecret.passwordDB,
  database: TokenSecret.database,
  server: TokenSecret.serverDB,
  pool: {
    max: 10,
    min: 0,
    idleTimeoutMillis: 30000
  },
  options: {
    encrypt: true,
    trustServerCertificate: true
  }
}

class DatabaseConnection3{
 
    getUser = async (commonUser,enabledUser) => {
      let useIDByQuery;
      if(enabledUser) useIDByQuery=`SELECT TOP 1 UserId FROM [FMS2].[auth].[HumanUsers] WHERE IsEnabled=${enabledUser}`;
      else useIDByQuery=`SELECT TOP 1 UserId FROM [FMS2].[auth].[HumanUsers] WHERE IsEnabled=${enabledUser}`;
      if(!commonUser) useIDByQuery=`SELECT TOP 1 UserId FROM [FMS2].[auth].[HumanUsers] WHERE EnterpriseId is not null`;
      
      try {
          await sql.connect(sqlConfig);
          const useID = await sql.query(useIDByQuery);
          const usename = await sql.query(`SELECT TOP 1 Username FROM [FMS2].[auth].[Users] WHERE UserId='${useID.recordset[0].UserId}'`);
          return usename.recordset[0].Username;
      } catch (err) {
        return err;
      }
  }

  getSpecialty = async (robotPipEnabled) => {
    let specialtyByQuery;
    specialtyByQuery=`SELECT TOP 1 Name FROM [FMS2].[auth].[Specialties] WHERE RobotPipEnabled=${robotPipEnabled}`;
    
    try {
        await sql.connect(sqlConfig);
        const specialtyName = await sql.query(specialtyByQuery);
         return specialtyName.recordset[0].Name;
    } catch (err) {
      return err;
    }
}

verifyUser = async (email,onlyRequired) => {
  let useIDByQuery=`SELECT TOP 1 * FROM [FMS2].[auth].[HumanUsers] WHERE Email='${email}'`;
  let connectivityGroupIdByQuery=`SELECT TOP 1 ConnectivityGroupId FROM [FMS2].[fms].[ConnectivityGroups] WHERE Name='${defaultValues.defaultConnectivityGroup}'`;
  let SpecialtyIdByQuery=`SELECT TOP 1 SpecialtyId FROM [FMS2].[auth].[Specialties] WHERE Name='${defaultValues.defaultSpecialty}'`;
  let StateIdByQuery=`SELECT TOP 1 StateId FROM [FMS2].[fms].[States] WHERE Name='${defaultValues.defaultState}'`;
  let UsersGroupIdByQuery=`SELECT TOP 1 UsersGroupId FROM [FMS2].[auth].[UsersGroups] WHERE Name='${defaultValues.defaultUsersGroup}'`;
  let OrganizationsIdByQuery=`SELECT TOP 2 OrganizationId FROM [FMS2].[fms].[Organizations] WHERE SfName='${defaultValues.defaultOrganizationLicense}' or SfName='${defaultValues.defaultOrganizationProviderId}'`;
  
  try {
      await sql.connect(sqlConfig);
      const userSaved = await sql.query(useIDByQuery);      
      const connectivityGroupSaved = await sql.query(connectivityGroupIdByQuery);
      const specialtySaved= await sql.query(SpecialtyIdByQuery);
      const stateSaved= await sql.query(StateIdByQuery);
      const usersGroupSaved= await sql.query(UsersGroupIdByQuery);
      const organizationsSaved= await sql.query(OrganizationsIdByQuery);
      

      let valuesSavedCorrectly= (userSaved.recordset[0].FirstName== defaultValues.defaultFirstName) &&
              (userSaved.recordset[0].LastName==  defaultValues.defaultLastName)&&
              (userSaved.recordset[0].Email== email) &&
              (userSaved.recordset[0].ConnectivityGroupId== connectivityGroupSaved.recordset[0].ConnectivityGroupId);

      if(onlyRequired){
        valuesSavedCorrectly = valuesSavedCorrectly &&
              (userSaved.recordset[0].Address== null)  &&
              (userSaved.recordset[0].Mobile== null)  &&
              (userSaved.recordset[0].OfficePhone== null)  &&
              (userSaved.recordset[0].Email2== null)  &&
              (userSaved.recordset[0].Title== null)  &&
              (userSaved.recordset[0].SpecialtyId== null)  &&
              (userSaved.recordset[0].Comments== null)  &&
              (userSaved.recordset[0].ChallengeQuestionId== null)  &&
              (userSaved.recordset[0].ChallengeQuestionTwoId== null)  &&
              (userSaved.recordset[0].ServiceLine== null)  &&
              (userSaved.recordset[0].City== null)  &&
              (userSaved.recordset[0].StateId== null)  &&
              (userSaved.recordset[0].Zip== null)  &&
              (userSaved.recordset[0].CountryId== null)  &&
              (userSaved.recordset[0].UsersGroupId== '1')  &&
              (userSaved.recordset[0].OrganizationLicenseId== null)  &&
              (userSaved.recordset[0].OrganizationProviderId== null)  &&
              (userSaved.recordset[0].PreferredTimezone== 'Pacific Standard Time')  &&
              (userSaved.recordset[0].IsEmployee== false)  &&
              (userSaved.recordset[0].IsEnabled== true)  &&
              (userSaved.recordset[0].NationalProviderIdentifier== null)  &&
              (userSaved.recordset[0].EpicEmpId== null);
      }else {
        valuesSavedCorrectly = valuesSavedCorrectly &&
              (userSaved.recordset[0].Address == defaultValues.defaultAddress)  &&
              (userSaved.recordset[0].Mobile == defaultValues.defaultMobile)  &&
              (userSaved.recordset[0].OfficePhone == defaultValues.defaultOfficePhone)  &&
              (userSaved.recordset[0].Email2 == defaultValues.defaultEmail2)  &&
              (userSaved.recordset[0].Title == defaultValues.defaultTitle)  &&
              (userSaved.recordset[0].SpecialtyId == specialtySaved.recordset[0].SpecialtyId)  &&
              (userSaved.recordset[0].Comments == defaultValues.defaultComments)  &&
              (userSaved.recordset[0].ChallengeQuestionId == defaultValues.defaultChallengeQuestionId)  &&
              (userSaved.recordset[0].ChallengeQuestionTwoId == defaultValues.defaultChallengeQuestionTwoId)  &&
              (userSaved.recordset[0].ServiceLine == defaultValues.defaultServiceLine)  &&
              (userSaved.recordset[0].City== defaultValues.defaultCity)  &&
              (userSaved.recordset[0].StateId== stateSaved.recordset[0].StateId)  &&
              (userSaved.recordset[0].Zip== defaultValues.defaultZip)  &&
              (userSaved.recordset[0].CountryId== defaultValues.defaultCountryId )  &&
              (userSaved.recordset[0].UsersGroupId== usersGroupSaved.recordset[0].UsersGroupId)  &&
              (userSaved.recordset[0].OrganizationLicenseId== organizationsSaved.recordset[0].OrganizationId)  &&
              (userSaved.recordset[0].OrganizationProviderId== organizationsSaved.recordset[1].OrganizationId)  &&
              (userSaved.recordset[0].PreferredTimezone== 'Alaskan Standard Time')  &&
              (userSaved.recordset[0].IsEmployee == true)  &&
              (userSaved.recordset[0].IsEnabled == true)  &&
              (userSaved.recordset[0].NationalProviderIdentifier == defaultValues.defaultNationalProviderIdentifier)  &&
              (userSaved.recordset[0].EpicEmpId == defaultValues.defaultEpicEmpId);
            }

    return valuesSavedCorrectly;
  
            } catch (err) {
    return err;
  }
}
   
}
module.exports = new DatabaseConnection3;