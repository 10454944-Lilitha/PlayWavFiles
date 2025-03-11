using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWavFiles
{
    class Program
    {
        static void Main(string[] args)
        { 
          WorkerClass worker = new WorkerClass();
          worker.SongChoice();
        }
    }
}
