using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetLUL
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var filename = "s:\\RJFAF903.LOC";
                foreach (var line in File.ReadAllLines(filename))
                {
                    if (line.StartsWith("RL70"))
                    {
                        var region = line[85];
                        var crs = line.Substring(56, 3);
                        var zone = line[83];
                        var zoneNlc = line.Substring(262, 6);
                        var endDate = line.Substring(9, 8);

                        if (endDate == "31122999" && zoneNlc.All(x=>x != 'Y') && "123456".Contains(zone) && (region == '6' || crs[0] == 'Z'))
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
