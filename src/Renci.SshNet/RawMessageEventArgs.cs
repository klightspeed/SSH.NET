using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renci.SshNet
{
    /// <summary>
    /// Contains the raw data for a message sent to or received from the server
    /// </summary>
    public class RawMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Contains the protocol name
        /// </summary>
        public string Source { get; set; }

#if NETSTANDARD2_0_OR_GREATER
        /// <summary>
        /// Contains the raw data for a message sent to or received from the server
        /// </summary>
        public ReadOnlyMemory<byte> Data { get; set; }
#else
        /// <summary>
        /// Contains the raw data for a message sent to or received from the server
        /// </summary>
        public byte[] Data { get; set; }
#endif

        /// <summary>
        /// Default constructor
        /// </summary>
        public RawMessageEventArgs()
        {
        }

        /// <summary>
        /// Constructor using byte array offset and count
        /// </summary>
        /// <param name="source"></param>
        /// <param name="data"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public RawMessageEventArgs(string source, byte[] data, int offset, int count)
        {
            Source = source;
#if NETSTANDARD2_0_OR_GREATER
            Data = data.AsMemory().Slice(offset, count);
#else
            Data = new byte[count];
            Array.Copy(data, offset, Data, 0, count);
#endif
        }
    }
}
