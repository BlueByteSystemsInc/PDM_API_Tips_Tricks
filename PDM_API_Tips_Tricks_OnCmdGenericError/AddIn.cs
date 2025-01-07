using BlueByte.SOLIDWORKS.PDMProfessional.SDK;
using BlueByte.SOLIDWORKS.PDMProfessional.SDK.Attributes;
using BlueByte.SOLIDWORKS.PDMProfessional.SDK.Diagnostics;
using BlueByte.SOLIDWORKS.PDMProfessional.SDK.Enums;
using EPDM.Interop.epdm;
using SimpleInjector;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace PDM_API_Tips_Tricks_OnCmdGenericError
{
    public enum Commands
    {
        ThrowError = 12345
    }

    [Menu((int)Commands.ThrowError, "Cause Error",(int)EdmMenuFlags.EdmMenu_Administration)]
    [ListenFor(EdmCmdType.EdmCmd_Menu)]
    [Name("PDM_API_Tips_Tricks_OnCmdGenericError")]
    [Description("Generic error on command ")]
    [CompanyName("Blue Byte Systems Inc.")]
    [AddInVersion(false, 1)]
    [IsTask(false)]
    [RequiredVersion(Year_e.PDM2014, ServicePack_e.SP0)]
    [ComVisible(true)]
    [Guid("d8db8f11-ce3a-4465-b9c2-85ff1ddca77c")]
    public partial class AddIn : AddInBase
    {

        public override void OnCmd(ref EdmCmd poCmd, ref EdmCmdData[] ppoData)
        {
            base.OnCmd(ref poCmd, ref ppoData);

            int handle = poCmd.mlParentWnd;

            if (poCmd.mlCmdID == (int)Commands.ThrowError) 
            throw new Exception("This is unhandled error"); 

        }


        protected override void OnLoggerTypeChosen(LoggerType_e defaultType)
        {
            base.OnLoggerTypeChosen(LoggerType_e.File);
        }

        protected override void OnRegisterAdditionalTypes(Container container)
        {
            // register types with the container 
        }

        protected override void OnLoggerOutputSat(string defaultDirectory)
        {
            // set the logger default directory - ONLY USE IF YOU ARE NOT LOGGING TO PDM
        }
        protected override void OnLoadAdditionalAssemblies(DirectoryInfo addinDirectory)
        {
            base.OnLoadAdditionalAssemblies(addinDirectory);
        }

        protected override void OnUnhandledExceptions(bool catchAllExceptions, Action<Exception> logAction = null)
        {
            this.CatchAllUnhandledException = false;

            logAction = (Exception e) =>
            {

                throw new NotImplementedException();
            };


            base.OnUnhandledExceptions(catchAllExceptions, logAction);
        }
    }
}