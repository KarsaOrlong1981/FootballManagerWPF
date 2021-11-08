using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FootballManager2021
{
    public class MatchResult
    {
        int plusForTeamA;
        int plusForTeamB;
        int goalsTeamA, goalsTeamB;
       
        int moralA, moralB, strengthA, strengthB, fitnessA, fitnessB, formA, formB, ageA, ageB, weigthA, weigthB, defenseA, defenseB, midA, midB, attA, attB, gKA, gKB,
            bodyStA, bodyStB, tacA, tacB, technicA, technicB, headerA, headerB, shootingA, shootingB, flankA, flankB, passA, passB, speedA, speedB, talentA, talentB;
        double sizeA, sizeB;
        Club club;
        List<string> goalsAssistsA, goalsAssistsB;
        
        List<Player> clubA, clubB, bestHeadShoot, bestPassFlank, poolGoals, poolAssists, finalGoalsA, finalGoalsB,finalAssistsA, finalAssistsB;
       
        public MatchResult(List<Player> clubA, List<Player> clubB)
        {
            goalsTeamA = 0;
            goalsTeamB = 0;

            this.clubA = clubA;
            this.clubB = clubB;
            club = new Club();
            goalsAssistsA = new List<string>();
            goalsAssistsB = new List<string>();
       
           /* PlayerComparsion(clubA, clubB, 1);
            int saveA = plusForTeamA;
            int saveB = plusForTeamB;
            PlayerComparsion(clubB, clubA, 2);
            plusForTeamA = plusForTeamA + saveA;
            plusForTeamB = plusForTeamB + saveB;*/
            GetBonusForOneTeam(clubA, clubB);
            GetFinalScore();
            //Team A
            //der Pool für die Torschützen
            bestHeadShoot = GetbestHeaderAndShooting(clubA);
            poolGoals = GetbestMoral(bestHeadShoot);
            //der Pool für die Vorlagengeber
            bestPassFlank = GetbestPassingAndFlanks(clubA);
            poolAssists = GetbestMoral(bestPassFlank);
            // das sind die Finalen Torschützen Team A
            finalGoalsA = GetScorerA(poolGoals);
            //das sind die Finalen Vorlagengeber Team A
            finalAssistsA = GetAssistsA(poolAssists);
            bestHeadShoot.Clear();
            bestPassFlank.Clear();
            poolGoals.Clear();
            poolAssists.Clear();
            //Team B
            //der Pool für die Torschützen
            bestHeadShoot = GetbestHeaderAndShooting(clubB);
            poolGoals = GetbestMoral(bestHeadShoot);
            //der Pool für die Vorlagengeber
            bestPassFlank = GetbestPassingAndFlanks(clubB);
            poolAssists = GetbestMoral(bestPassFlank);
            // das sind die Finalen Torschützen Team B
            finalGoalsB = GetScorerB(poolGoals);
            //das sind finalen Vorlagengeber Team B
            finalAssistsB = GetAssistsB(poolAssists);
            bestHeadShoot.Clear();
            bestPassFlank.Clear();
            poolAssists.Clear();
            poolGoals.Clear();

            Debug.WriteLine("Team A: " + goalsTeamA);
            Debug.WriteLine("Team B: " + goalsTeamB);
         
            Debug.WriteLine("Team A: " + plusForTeamA);
            Debug.WriteLine("Team B: " + plusForTeamB);
        }
        public List<string> GetGoalsAssistForGameTeamA()
        {
            for (int i = 0; i < goalsTeamA; i++)
            {
                goalsAssistsA.Add(finalGoalsA[i].Forename + " " + finalGoalsA[i].Surname + " durch Vorlage von " + finalAssistsA[i].Forename + " " + finalAssistsA[i].Surname);
                Debug.WriteLine("Tor Team A: " + finalGoalsA[i].Surname + " durch Vorlage von: " + finalAssistsA[i].Surname);
            }
            return goalsAssistsA;
        }
        public List<string> GetGoalsAssistForGameTeamB()
        {
            
            for (int i = 0; i < goalsTeamB; i++)
            {
                goalsAssistsB.Add(finalAssistsB[i].Forename + " " + finalGoalsB[i].Surname + " durch Vorlage von " + finalAssistsB[i].Forename + " " + finalAssistsB[i].Surname);
                Debug.WriteLine("Tor Team B: " + finalGoalsB[i].Surname + " durch Vorlage von: " + finalAssistsB[i].Surname);
            }
            return goalsAssistsB;
        }
        public string GetFinalresult()
        {

            string result = goalsTeamA + " : " + goalsTeamB;
            return result;
        }
        private List<Player> GetScorerA(List<Player> clubA)
        {
            List<Player> scorer = new List<Player>();
            Random rndScorer = new Random();
            int stScores = rndScorer.Next(0, goalsTeamA);
            bool stScoresOneTime = false;
            for (int i = 0; i < goalsTeamA; i++)
            {
                if (i == stScores && stScoresOneTime == false)
                {
                    foreach (var player in clubA)
                    {
                        if (player.Position == "ST")
                        {
                            scorer.Add(player);
                            stScoresOneTime = true;
                            break;
                        }
                    }
                }
                else
                {
                    scorer.Add(clubA[rndScorer.Next(0, clubA.Count)]);
                }
                
            }
            return scorer;
        }
        private List<Player> GetAssistsA(List<Player> clubA)
        {
            List<Player> assist = new List<Player>();
            Random rndScorer = new Random();
           
            for (int i = 0; i < goalsTeamA; i++)
            {
                assist.Add(clubA[rndScorer.Next(0, clubA.Count)]);
                if (assist[i] == finalGoalsA[i])
                {
                    assist.Remove(clubA[i]);
                    int rnd = rndScorer.Next(0, clubA.Count);
                    while (rnd == i)
                    {
                        
                        rnd = rndScorer.Next(0, clubA.Count);
                        
                    }
                    assist.Add(clubA[rnd]);
                }
            }
            return assist;
        }
        private List<Player> GetAssistsB(List<Player> clubB)
        {
            List<Player> assist = new List<Player>();
            Random rndScorer = new Random();

            for (int i = 0; i < goalsTeamB; i++)
            {
                assist.Add(clubB[rndScorer.Next(0, clubB.Count)]);
                int rnd = rndScorer.Next(0, clubB.Count);
                while (rnd == i)
                {

                    rnd = rndScorer.Next(0, clubB.Count);

                }
                assist.Add(clubB[rnd]);
            }
            return assist;
        }
        private List<Player> GetScorerB(List<Player> clubB)
        {
            List<Player> scorer = new List<Player>();
            Random rndScorer = new Random();
            bool stScoresOneTime = false;
            for (int i = 0; i < goalsTeamB; i++)
            {
                if (i == rndScorer.Next(0, goalsTeamB) && stScoresOneTime == false)
                {
                    foreach (var player in clubB)
                    {
                        if (player.Position == "ST")
                        {
                            scorer.Add(clubB[rndScorer.Next(0, clubB.Count)]);
                            stScoresOneTime = true;
                        }
                    }
                }
                else
                {
                    scorer.Add(clubB[rndScorer.Next(0, clubB.Count)]);
                }

            }
            return scorer;
        }
        public  void GetFinalScore()
        {
            //Differenz aus plusPunkten ziehen 
            //Standard möglicher Tore = 4 + folgende PlusPunkte:
            // 0 - 5  = +1 gegner - 1
            // 5 - 10 = +2 gegner - 1
            //10 - 15 = +3 gegner - 1
            //15 - 20 = +4
            //20 - 25 = +5
            Random random = new Random();
            int differenz = 0;
            int bonus = 0;
            int malus = 0;
            bool home = false;
            bool away = false;
            if (plusForTeamA > plusForTeamB)
            {
                home = true;
                differenz = plusForTeamA - plusForTeamB;

            }
            if (plusForTeamA < plusForTeamB)
            {
                away = true;
                differenz = plusForTeamB - plusForTeamA;

            }

            if (differenz > 0 && differenz <= 5)
            {
                bonus = 1;
                malus = 1;
            }
            if (differenz > 5 && differenz <= 10)
            {
                bonus = 2;
                malus = 2;
            }
            if (differenz > 10 && differenz <= 15)
            {
                bonus = 3;
                malus = 2;
            }
            if (differenz > 15 && differenz <= 20)
            {
                bonus = 4;
                malus = 2;
            }
            if (differenz > 20 && differenz <= 25)
            {
                bonus = 5;
                malus = 2;
            }

            if (plusForTeamA == plusForTeamB)
            {
                goalsTeamA = random.Next(0, 4);
                goalsTeamB = random.Next(0, 4);
            }
            if (home == true)
            {
                goalsTeamA = random.Next(0, 4 + bonus);
                goalsTeamB = random.Next(0, 4 - malus);
            }
            if (away == true)
            {
                goalsTeamA = random.Next(0, 4 - malus);
                goalsTeamB = random.Next(0, 4 + bonus);
            }
           
        }
        //An diese methoden dürfen nur die Startaufstellungen übergeben werden,
        //während einem Spiel muss diese Methode bei jeder Auswechslung erneut
        //aufgerufen werden um die daten zu aktualisieren
        void SetBonusForTeamA(List<Player> clubA)
        {
            int moral = 0;
            int playerCount = 0;
            int teamStrength = 0;
            int fitness = 0;
            int form = 0;
            int age = 0;
            int weigth = 0;
            double size = 0;
            int defense = 0;
            int midfield = 0;
            int attack = 0;
            int goalkeep = 0;
            int bodyST = 0;
            int tac = 0;
            int technic = 0;
            int header = 0;
            int shoot = 0;
            int flank = 0;
            int pass = 0;
            int speed = 0;
            int talent = 0;
            foreach (var player in clubA)
            {
                playerCount++;
                moral = moral + player.Moral;
                teamStrength = teamStrength + player.Strength;
                fitness = fitness + player.Fitness;
                form = form + player.Form;
                age = age + player.Age;
                weigth = weigth + player.Weigth;
                size = size + player.Size;
                defense = defense + player.Defense;
                midfield = midfield + player.Midfield;
                attack = attack + player.Attack;
                goalkeep = goalkeep + player.GoalKeeping;
                bodyST = bodyST + player.BodyStrength;
                tac = tac + player.Tactical;
                technic = technic + player.TechnicSkill;
                header = header + player.Header;
                shoot = shoot + player.Shooting;
                flank = flank + player.Flanks;
                pass = pass + player.Passing;
                speed = speed + player.Speed;
                talent = talent + player.Talent;
            }
            moralA = moral / playerCount;
            strengthA = teamStrength / playerCount;
            fitnessA = fitness / playerCount;
            formA = form / playerCount;
            ageA = age / playerCount;
            weigthA = weigth / playerCount;
            sizeA = size / playerCount;
            defenseA = defense / playerCount;
            midA = midfield / playerCount;
            attA = attack / playerCount;
            gKA = goalkeep / playerCount;
            bodyStA = bodyST / playerCount;
            tacA = tac / playerCount;
            technicA = technic / playerCount;
            headerA = header / playerCount;
            shootingA = shoot / playerCount;
            flankA = flank / playerCount;
            passA = pass / playerCount;
            speedA = speed / playerCount;
            talentA = talent / playerCount;
           

        }
        void SetBonusForTeamB(List<Player> clubB)
        {
            int moral = 0;
            int playerCount = 0;
            int teamStrength = 0;
            int fitness = 0;
            int form = 0;
            int age = 0;
            int weigth = 0;
            double size = 0;
            int defense = 0;
            int midfield = 0;
            int attack = 0;
            int goalkeep = 0;
            int bodyST = 0;
            int tac = 0;
            int technic = 0;
            int header = 0;
            int shoot = 0;
            int flank = 0;
            int pass = 0;
            int speed = 0;
            int talent = 0;
            foreach (var player in clubB)
            {
                playerCount++;
                moral = moral + player.Moral;
                teamStrength = teamStrength + player.Strength;
                fitness = fitness + player.Fitness;
                form = form + player.Form;
                age = age + player.Age;
                weigth = weigth + player.Weigth;
                size = size + player.Size;
                defense = defense + player.Defense;
                midfield = midfield + player.Midfield;
                attack = attack + player.Attack;
                goalkeep = goalkeep + player.GoalKeeping;
                bodyST = bodyST + player.BodyStrength;
                tac = tac + player.Tactical;
                technic = technic + player.TechnicSkill;
                header = header + player.Header;
                shoot = shoot + player.Shooting;
                flank = flank + player.Flanks;
                pass = pass + player.Passing;
                speed = speed + player.Speed;
                talent = talent + player.Talent;
            }
            moralB = moral / playerCount;
            strengthB = teamStrength / playerCount;
            fitnessB = fitness / playerCount;
            formB = form / playerCount;
            ageB = age / playerCount;
            weigthB = weigth / playerCount;
            sizeB = size / playerCount;
            defenseB = defense / playerCount;
            midB = midfield / playerCount;
            attB = attack / playerCount;
            gKB = goalkeep / playerCount;
            bodyStB = bodyST / playerCount;
            tacB = tac / playerCount;
            technicB = technic / playerCount;
            headerB = header / playerCount;
            shootingB = shoot / playerCount;
            flankB = flank / playerCount;
            passB = pass / playerCount;
            speedB = speed / playerCount;
            talentB = talent / playerCount;
        }
        //Die Torschützen aus den Spielen erstelle ich aus folgender formel-
        //aus dem aktuell aufgestllten Team die höchsten werte aus Header-Shooting-Moral-
        //Diese Spieler kommen dann in einen Pool der so groß ist wie die vom eigenen Team geschossenen Tore wo sie nun per random wert zugewiesen werden.
        //Vorlagengeber werden auch in einen Pool aufgennommen dort wird nach folgenden Werten ausgeschlossen: Passing-Moral-Flanks-Tactical
        //Dieser Methode darf nur die Startaufstellung mit ersatzspielern übergeben werden dabei wird vor dem Spiel verglichen
        //welche 3 Spieler die niedrigsten werte in Form-Fitness-Moral haben, diese werden dann durch passende Positionen ersetzt.
        //Alle anderen ErsatzSpieler werden nun aus dem Kader für das Aktuelle Spiel gelöscht
        //Die Eingewechselten Spieler werden dann so auch in den vergleich zum Torschützen und Vorlagengeber mit einbezogen
        List<Player> GetbestHeaderAndShooting(List<Player> club)
        {
            
            List<Player> poolHeadShoot = new List<Player>();
            foreach (var player in club)
            {
                if (!(player.Position == "TW"))
                {
                    for (int i = 0; i < club.Count; i++)
                    {
                        if (!(club[i].Position == "TW"))
                        {
                            if (player == club[i])
                            {
                                continue;
                            }
                            else
                            {
                                if (player.Header > club[i].Header && player.Shooting > club[i].Shooting)
                                {
                                    if (!(poolHeadShoot.Contains(player)))
                                    poolHeadShoot.Add(player);
                                }
                                else
                                {

                                    if (!(poolHeadShoot.Contains(club[i])))
                                        poolHeadShoot.Add(club[i]);
                                    if (poolHeadShoot.Contains(player))
                                        poolHeadShoot.Remove(player);
                                }
                            }
                        }
                    }
                }
            }
            return poolHeadShoot;
        }
        List<Player> GetbestPassingAndFlanks(List<Player> club)
        {

            List<Player> poolpassFlank = new List<Player>();
            foreach (var player in club)
            {
                if (!(player.Position == "TW"))
                {
                    for (int i = 0; i < club.Count; i++)
                    {
                        if (!(club[i].Position == "TW"))
                        {
                            if (player == club[i])
                            {
                                continue;
                            }
                            else
                            {
                                if (player.Passing > club[i].Passing && player.Flanks > club[i].Flanks)
                                {
                                    if (!(poolpassFlank.Contains(player)))
                                        poolpassFlank.Add(player);
                                }
                                else
                                {

                                    if (!(poolpassFlank.Contains(club[i])))
                                        poolpassFlank.Add(club[i]);
                                    if (poolpassFlank.Contains(player))
                                        poolpassFlank.Remove(player);
                                }
                            }
                        }
                    }
                }
            }
            return poolpassFlank;
        }
        List<Player> GetbestMoral(List<Player> club)
        {

            List<Player> poolMoralFit = new List<Player>();
            foreach (var player in club)
            {
                if (!(player.Position == "TW"))
                {
                    for (int i = 0; i < club.Count; i++)
                    {
                        if (!(club[i].Position == "TW"))
                        {
                            if (player == club[i])
                            {
                                continue;
                            }
                            else
                            {
                                if (player.Moral > club[i].Moral)
                                {
                                    if (!(poolMoralFit.Contains(player)))
                                        poolMoralFit.Add(player);
                                }
                                else
                                {

                                    if (!(poolMoralFit.Contains(club[i])))
                                        poolMoralFit.Add(club[i]);
                                    if (poolMoralFit.Contains(player))
                                        poolMoralFit.Remove(player);
                                }
                            }
                        }
                    }
                }
            }
            return poolMoralFit;
        }
        void GetBonusForOneTeam(List<Player> clubA, List<Player> clubB)
        {
            SetBonusForTeamA(clubA);
            SetBonusForTeamB(clubB);
            //erst bonus und malus für age, weigth und size setzen
            //age = wenn < dann Form und Fitness + 5\ weigth = wenn > Bodystrength + 5 und speed - 5\ size = wenn > Header + 5 speed + 5 technic - 5\ 
            if (ageA > ageB && !(ageA == ageB))
            {
                fitnessB = fitnessB + 5;
                formB = formB + 5;
            }
            else
            {
                fitnessA = fitnessA + 5;
                formA = formA + 5;
            }
            if (weigthA > weigthB && !(weigthA == weigthB))
            {
                bodyStA = bodyStA + 5;
                speedA = speedA - 5;
            }
            else
            {
                bodyStB = bodyStB + 5;
                speedB = speedB - 5;
            }
            if (sizeA > sizeB && !(sizeA == sizeB))
            {
                headerA = headerA + 5;
                speedA = speedA + 5;
                technicA = technicA - 5;
            }
            else
            {
                headerB = headerB + 5;
                speedB = speedB + 5;
                technicB = technicB - 5;
            }
            //jetzt die differenzen ziehen
            if (moralA > moralB && !(moralA == moralB))
            {
                int differenz = moralA - moralB;
                Debug.WriteLine("Moraldiff(A): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamA = plusForTeamA + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamA = plusForTeamA + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamA = plusForTeamA + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamA = plusForTeamA + 10;
                }
            }
            else
            {
                int differenz = moralB - moralA;
                Debug.WriteLine("Moraldiff(B): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamB = plusForTeamB + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamB = plusForTeamB + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamB = plusForTeamB + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamB = plusForTeamB + 10;
                }
            }
            if (strengthA > strengthB && !(strengthA == strengthB))
            {
                int differenz = strengthA - strengthB;
                Debug.WriteLine("strenghtdiff(A): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamA = plusForTeamA + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamA = plusForTeamA + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamA = plusForTeamA + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamA = plusForTeamA + 10;
                }

            }
            else
            {
                int differenz = strengthB - strengthA;
                Debug.WriteLine("strenghtdiff(B): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamB = plusForTeamB + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamB = plusForTeamB + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamB = plusForTeamB + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamB = plusForTeamB + 10;
                }
            }
            if (fitnessA > fitnessB && !(fitnessA == fitnessB))
            {
                int differenz = fitnessA - fitnessB;
                Debug.WriteLine("fitdiff(A): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamA = plusForTeamA + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamA = plusForTeamA + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamA = plusForTeamA + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamA = plusForTeamA + 10;
                }

            }
            else
            {
                int differenz = fitnessB - fitnessA;
                Debug.WriteLine("fitdiff(B): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamB = plusForTeamB + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamB = plusForTeamB + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamB = plusForTeamB + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamB = plusForTeamB + 10;
                }
            }
            if (formA > formB && !(formA == formB))
            {
                int differenz = formA - formB;
                Debug.WriteLine("formdiff(A): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamA = plusForTeamA + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamA = plusForTeamA + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamA = plusForTeamA + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamA = plusForTeamA + 10;
                }

            }
            else
            {
                int differenz = formB - formA;
                Debug.WriteLine("formdiff(B): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamB = plusForTeamB + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamB = plusForTeamB + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamB = plusForTeamB + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamB = plusForTeamB + 10;
                }
            }
            if (defenseA > defenseB && !(defenseA == defenseB))
            {
                int differenz = defenseA - defenseB;
                Debug.WriteLine("defdiff(A): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamA = plusForTeamA + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamA = plusForTeamA + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamA = plusForTeamA + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamA = plusForTeamA + 10;
                }

            }
            else
            {
                int differenz = defenseB - defenseA;
                Debug.WriteLine("defdiff(B): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamB = plusForTeamB + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamB = plusForTeamB + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamB = plusForTeamB + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamB = plusForTeamB + 10;
                }
            }
            if (midA > midB && !(midA == midB ))
            {
                int differenz = midA - midB;
                Debug.WriteLine("middiff(A): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamA = plusForTeamA + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamA = plusForTeamA + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamA = plusForTeamA + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamA = plusForTeamA + 10;
                }

            }
            else
            {
                int differenz = midA - midB;
                Debug.WriteLine("middiff(B): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamB = plusForTeamB + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamB = plusForTeamB + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamB = plusForTeamB + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamB = plusForTeamB + 10;
                }
            }
            if (attA > attB && !(attA == attB))
            {
                int differenz = attA - attB;
                Debug.WriteLine("Attackdiff(A): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamA = plusForTeamA + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamA = plusForTeamA + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamA = plusForTeamA + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamA = plusForTeamA + 10;
                }

            }
            else
            {
                int differenz = attB - attA;
                Debug.WriteLine("Attackdiff(B): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamB = plusForTeamB + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamB = plusForTeamB + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamB = plusForTeamB + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamB = plusForTeamB + 10;
                }
            }
            if (gKA > gKB && !(gKA == gKB))
            {
                int differenz = gKA - gKB;
                Debug.WriteLine("GKdiff(A): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamA = plusForTeamA + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamA = plusForTeamA + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamA = plusForTeamA + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamA = plusForTeamA + 10;
                }

            }
            else
            {
                int differenz = gKB - gKA;
                Debug.WriteLine("GKdiff(B): " + differenz);
                if (differenz > 0 && differenz <= 10)
                {
                    plusForTeamB = plusForTeamB + 2;
                }
                if (differenz > 10 && differenz <= 20)
                {
                    plusForTeamB = plusForTeamB + 5;
                }
                if (differenz > 20 && differenz <= 30)
                {
                    plusForTeamB = plusForTeamB + 8;
                }
                if (differenz > 30)
                {
                    plusForTeamB = plusForTeamB + 10;
                }
            }
            //Noch weiter machen
        }
      
    }
}
