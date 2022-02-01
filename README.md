# UNS - Testing Automation Tools

## Implementación en Cypress:

### Instalación:
1. Instalar Node JS. Para ello debemos ingresar al siguiente sitio https://nodejs.org/es/ y descargar e instalar la versión TLS.
2. Instalar Visual Studio Code. Pueden descargarlo desde el siguiente enlace https://code.visualstudio.com/ . Seleccionar la opción Stable Build.
3. Isntalar Cypress usando la consola de comandos: ```npm install –save-dev cypress```

### Configuración:
1. Crear un archivo cypress.json dentro de la carpeta **\cypress**.
* Completar los valores con la información necesaria para acceder a la base de datos y la url base del FMS Web Portal correspondiente al environment elegido. 
2. Crear un archivo envValues.json dentro de la carpeta **\cypress\cypress\fixtures**
* Completar los datos necesarios para el login del usuario.

### Ejecución:
En una consola de comandos ejecutar el siguiente comando:
```
./node_modules/.bin/cypress open
```


## Implementación en Robot Framework:

### Instalación:
1. Instalar python
2. Instalar un IDE como Sublime Text 3
3. Instalar robot Framework para python usando la consola de comandos: ```pip install robotframework```
4. Intalar libreria de Selenium para robot Framework
5. Instalar pymssql usando la consola de comandos: ```pip install pymssql```
6. Instalar robotframework-databaselibrary usando la consola de comandos: ```pip install -U robotframework-databaselibrary```

### Configuracion:
1. Modificar los archivos environment.py y TokenSecret.py dentro de la carpeta **\Resources\Testdata**.
* Los archivos deben contener la información necesaria para acceder a la base de datos y la url base del FMS Web Portal correspondiente al environment elegido. 

### Ejecución:
En una consola de comandos ejecutar el siguiente comando:
```
cd ./RobotFramework/Tests/Specialties 
python -m robot TC1.robot

cd ./RobotFramework/Tests/Database 
python -m robot database.robot

cd ./RobotFramework/Tests/Username 
python -m robot username.robot
```


## Implementación en Cucumber:

### Instalación:
1. Descargar e instalar Java (SDK) for developers desde https://www.oracle.com/
2. Intalar Node js LTS	https://nodejs.org/en/download/
3. Instalar Visual Studio Code desde https://code.visualstudio.com/

Para iniciar un nuevo proyecto:
1. Instalar WebdriverIO usando la consola de comandos: ```npm i webdriverio @wdio/cli```
2. npm i wdio-chromedriver-service

### Configuracion:
Habilitar ejecución de archivos .ps1 en Windows. Para esto ejecutar desde PowerShell ```Set-ExecutionPolicy -Scope LocalMachine unrestricted```

### Ejecución:
En una consola de comandos ejecutar el siguiente comando:
```
cd ./Cucumber
npx wdio run wdio.conf.js
./node_modules/.bin/wdio ./wdio.conf.js
```

#### Configuracion extra:
npx wdio run wdio.conf.js, 
{
            logFileName: 'wdio-chromedriver.log', // default
            outputDir: 'driver-logs', // overwrites the config.outputDir
            args: ['--silent']
        }