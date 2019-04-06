using System.Diagnostics;

namespace Berry.Util.NetworkMonitor
{
    /// <summary>
    /// Represents a network adapter installed on the machine.
    /// Properties of this class can be used to obtain current network speed.
    /// </summary>
    public class NetworkAdapter
    {
        /// <summary>
        /// Instances of this class are supposed to be created only in an NetworkMonitor.
        /// </summary>
        internal NetworkAdapter(string name)
        {
            this.name = name;
        }

        private long dlSpeed, ulSpeed;              // Download\Upload speed in bytes per second.
        private long dlValue, ulValue;              // Download\Upload counter value in bytes.
        private long dlValueOld, ulValueOld;        // Download\Upload counter value one second earlier, in bytes.

        internal string name;                               // The name of the adapter.
        internal PerformanceCounter dlCounter, ulCounter;   // Performance counters to monitor download and upload speed.

        /// <summary>
        /// Preparations for monitoring.
        /// </summary>
        internal void Init()
        {
            // Since dlValueOld and ulValueOld are used in method refresh() to calculate network speed, they must have be initialized.
            this.dlValueOld = this.dlCounter.NextSample().RawValue;
            this.ulValueOld = this.ulCounter.NextSample().RawValue;
        }

        /// <summary>
        /// Obtain new sample from performance counters, and refresh the values saved in dlSpeed, ulSpeed, etc.
        /// This method is supposed to be called only in NetworkMonitor, one time every second.
        /// </summary>
        internal void Refresh()
        {
            this.dlValue = this.dlCounter.NextSample().RawValue;
            this.ulValue = this.ulCounter.NextSample().RawValue;

            // Calculates download and upload speed.
            this.dlSpeed = this.dlValue - this.dlValueOld;
            this.ulSpeed = this.ulValue - this.ulValueOld;

            this.dlValueOld = this.dlValue;
            this.ulValueOld = this.ulValue;
        }

        /// <summary>
        /// Overrides method to return the name of the adapter.
        /// </summary>
        /// <returns>The name of the adapter.</returns>
        public override string ToString()
        {
            return this.name;
        }

        /// <summary>
        /// The name of the network adapter.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }
        /// <summary>
        /// Current download speed in bytes per second.
        /// </summary>
        public long DownloadSpeed
        {
            get
            {
                return this.dlSpeed;
            }
        }
        /// <summary>
        /// Current upload speed in bytes per second.
        /// </summary>
        public long UploadSpeed
        {
            get
            {
                return this.ulSpeed;
            }
        }
        /// <summary>
        /// Current download speed in kbytes per second.
        /// </summary>
        public double DownloadSpeedKbps
        {
            get
            {
                return this.dlSpeed / 1024.0;
            }
        }
        /// <summary>
        /// Current upload speed in kbytes per second.
        /// </summary>
        public double UploadSpeedKbps
        {
            get
            {
                return this.ulSpeed / 1024.0;
            }
        }
    }
}
