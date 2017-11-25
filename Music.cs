static void Music()
        {
            //Together We Ride
            int i = 0;
            string s = "eEE5fFF6gGG7fFF6eEE5eEE5mMM(nNN-oOO_nNN-mMM(M  Mt&ty?t&ty?t&ty?vavY#&D##&#AL#&#AL#&#ALasavavy#"
                       + "y#&l+y#&l+y#&l!MmR."
                       + "eEE5fFF6gGG7fFF6eEE5eEE5mMM(nNN-oOO_nNN-mMM(M  Mt&ty?t&ty?t&ty?vavY#&D##&#AL#&#AL#&#ALasavavy"
                       + "#y#&l+y#&l+y#&l!MmR."
                       + "KmR.mR.mR.mR mR.mR.mR.mR";
            while (i < s.Length)
            {
                if (s[i] == 'e')
                    Console.Beep(330, 450);
                else if (s[i] == 'E')    
                    Console.Beep(330, 300);
                else if (s[i] == '5')
                    Console.Beep(330, 150);
                else if (s[i] == 'f')
                    Console.Beep(349, 450);
                else if (s[i] == 'F')
                    Console.Beep(349, 300);
                else if (s[i] == '6')
                    Console.Beep(349, 150);
                else if (s[i] == 'g')
                    Console.Beep(392, 450);
                else if (s[i] == 'G')
                    Console.Beep(392, 300);
                else if (s[i] == '7')
                    Console.Beep(392, 150);
                else if (s[i] == 'm')
                    Console.Beep(659, 450);
                else if (s[i] == 'M')
                    Console.Beep(659, 300);
                else if (s[i] == '(')
                    Console.Beep(659, 150);
                else if (s[i] == 'n')
                    Console.Beep(698, 450);
                else if (s[i] == 'N')
                    Console.Beep(698, 300);
                else if (s[i] == '-')
                    Console.Beep(698, 150);
                else if (s[i] == 'o')
                    Console.Beep(784, 450);
                else if (s[i] == 'O')
                    Console.Beep(784, 300);
                else if (s[i] == '_')
                    Console.Beep(784, 150);
                else if (s[i] == '&')
                    Console.Beep(587, 100);
                else if (s[i] == '?')
                    Console.Beep(698, 600);
                else if (s[i] == 't')
                    Console.Beep(659, 100);
                else if (s[i] == 'y')
                    Console.Beep(698, 250);
                else if (s[i] == 'v')
                    Console.Beep(784, 100);
                else if (s[i] == 'a')
                    Console.Beep(880, 100);
                else if (s[i] == 'Y')
                    Console.Beep(698, 100);
                else if (s[i] == '#')
                    Console.Beep(659, 100);
                else if (s[i] == 'D')
                    Console.Beep(554, 100);
                else if (s[i] == 'A')
                    Console.Beep(880, 200);
                else if (s[i] == 'L')
                    Console.Beep(880, 600);
                else if (s[i] == 's')
                    Console.Beep(932, 100);
                else if (s[i] == 'l')
                    Console.Beep(440, 250);
                else if (s[i] == '+')
                    Console.Beep(440, 600);
                else if (s[i] == '!')
                    Console.Beep(440, 300);
                else if (s[i] == 'R')
                    Console.Beep(587, 450);
                else if (s[i] == '.')
                    Console.Beep(880, 300);
                else if (s[i] == 'K')
                    Console.Beep(587, 1200);
                else if (s[i] == 'k')
                    Console.Beep(440, 1200);
                else if (s[i] == 'r')
                    Console.Beep(587, 600);
                else if (s[i] == ' ')
                    Thread.Sleep(300);
                else
                    Console.WriteLine("Music: Error");
                i++;    
            }
            
        }
