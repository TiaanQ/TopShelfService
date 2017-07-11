namespace TopShelfService.Models
{
    class ServiceRecovery
    {
        private int restartServiceDelay = 0;
        public int RestartServiceDelay
        {
            get { return restartServiceDelay; }
            set { restartServiceDelay = value; }
        }

        private int runProgramDelay = 0;
        public int RunProgramDelay
        {
            get { return runProgramDelay; }
            set { runProgramDelay = value; }
        }

        private string runProgramName = string.Empty;
        public string RunProgramName
        {
            get { return runProgramName; }
            set { runProgramName = value; }
        }

        private int resetPeriod = 0;
        public int ResetPeriod
        {
            get { return resetPeriod; }
            set { resetPeriod = value; }
        }
    }
}