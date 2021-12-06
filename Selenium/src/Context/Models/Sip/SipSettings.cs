using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Context.Constants;

namespace FmsDbContext
{
    [Table(nameof(SipSettings), Schema = Schemas.Sip)]
    public partial class SipSettings
    {
        public SipSettings()
        {
            DomainId = 1;
        }

        [Key]
        public long SipSettingsId { get; set; }

        public bool AutoRecordInCloud { get; set; }

        public bool AutoRecordSession { get; set; }

        public bool CanSaveMedia { get; set; }

        public bool CanTelestrate { get; set; }

        public string DisplayName { get; set; }

        public long? DomainId { get; set; }

        public bool FrameGrabber { get; set; }

        public bool HostRoleOverride { get; set; }

        public bool IdentityProviderAuthentication { get; set; }

        public bool LocalAudioMuted { get; set; }

        public bool LocalSnapshot { get; set; }

        public bool LocalVideoMuted { get; set; }

        public bool Multipresence { get; set; }

        public bool MultipresenceAcceptGuest { get; set; }

        public byte? MultipresenceRole { get; set; }

        public bool RecordLocalVideo { get; set; }

        public bool RecordRemoteVideo { get; set; }

        public bool RemoteSnapshot { get; set; }

        public bool RobotPipEnabled { get; set; }

        public bool SoloTheme { get; set; }

        public bool StrokeAssessment { get; set; }

        public bool WebPas { get; set; }
    }
}