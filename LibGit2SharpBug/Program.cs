using System;
using System.Globalization;
using System.IO;
using System.Linq;
using LibGit2Sharp;

namespace LibGit2SharpBug
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length < 1 || !Directory.Exists(args[0]))
            {
                Console.Error.WriteLine("Usage: app /path/to/git/repo");
                return -1;
            }

            try
            {
                var repoPath = args[0];
                using var repo = new Repository(repoPath);
                const string rfc2822Format = "ddd dd MMM HH:mm:ss yyyy K";

                foreach (var c in repo.Commits.Take(15))
                {
                    Console.WriteLine("commit {0}", c.Id);

                    if (c.Parents.Count() > 1)
                    {
                        Console.WriteLine("Merge: {0}",
                            string.Join(" ", c.Parents.Select(p => p.Id.Sha.Substring(0, 7)).ToArray()));
                    }

                    Console.WriteLine("Author: {0} <{1}>", c.Author.Name, c.Author.Email);
                    Console.WriteLine("Date:   {0}", c.Author.When.ToString(rfc2822Format, CultureInfo.InvariantCulture));
                    Console.WriteLine();
                    Console.WriteLine(c.Message);
                    Console.WriteLine();
                }

                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error occurred: {0}", e.ToString());
                return -2;
            }

            return 0;
        }
    }
}
