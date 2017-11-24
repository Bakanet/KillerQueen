static void Music()
        {
            //Together We Ride
            int i = 0;
            string s = "eEE5fFF6gGG7fFF6eEE5eEE5mMM(nNN-oOO_nNN-mMM(M  M(&(-?(&(-?(&(-?";
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
                    Console.Beep(587, 150);
                else if (s[i] == '?')
                    Console.Beep(698, 600);
                else if (s[i] == ' ')
                    Thread.Sleep(300);
                i++;    
            }
            
        }
    }
