using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FootballManager2021
{
    public class CreatClubs
    {
        //Wenn neues Spiel geklickt wird sollen die Teams einmal erstellt werden und dann gespeichert werden,
        //bei jedem neuen spiel wird die vorhandene datei überschrieben oder in eine neue datei gelegt
        //England
      
        Player player;
        Random rndForeNames;
        Random rndSureNames;
        Random rndFoot;
        Random random = new Random();
        // English League, one List for every Team
        List<Player> manU, lndonClocks, chelseaLions, liverpoolFlames, manCitizen, westHamUnion, wolverhamptonWolves, brightonHoveAlbatros, tottenHamColdspurs, evertonUnited, leicesterFoxes,
            brentfordNational, crystalPalaceEagles, southamptonTrees, astonVillaGoldenLions, watfordCity, leedsUnion, burnleyStorms, newcastleRoyals, norwichBirds;
        // To Create an League
        List<Club> league;
        Club club;
        public CreatClubs()
        {
            manU = new List<Player>();
            lndonClocks = new List<Player>();
            chelseaLions = new List<Player>();
            liverpoolFlames = new List<Player>();
            manCitizen = new List<Player>();
            westHamUnion = new List<Player>();
            wolverhamptonWolves = new List<Player>();
            brightonHoveAlbatros = new List<Player>();
            tottenHamColdspurs = new List<Player>();
            evertonUnited = new List<Player>();
            leicesterFoxes = new List<Player>();
            brentfordNational = new List<Player>();
            crystalPalaceEagles = new List<Player>();
            southamptonTrees = new List<Player>();
            astonVillaGoldenLions = new List<Player>();
            watfordCity = new List<Player>();
            leedsUnion = new List<Player>();
            burnleyStorms = new List<Player>();
            newcastleRoyals = new List<Player>();
            norwichBirds = new List<Player>();
            rndForeNames = new Random();
            rndSureNames = new Random();
            rndFoot = new Random();
            league = new List<Club>();
            club = new Club();
        }
        public void AddnewPlayerToTeam(List<Player> team, Player player)
        {
            team.Add(player);
        }
        public void RemovePlayerFromTeam(List<Player> team, Player player)
        {
            team.Remove(player);
        }
        private string SetFoot()
        {
            string foot = string.Empty;
            string[] leftRigthBoth = { "Rechts", "Links", "Beide" };
            foot = leftRigthBoth[rndFoot.Next(0, leftRigthBoth.Length)];
            return foot;
        }
        private string GetAvatar()
        {
            string avatar = string.Empty;
            string[] avatarArray = { "pics/avataaars.png", "pics/BlackRed.png", "pics/BlondRed.png", "pics/WhiteRed.png","pics/GoldRed.png", "pics/RedRed.png", "pics/GrausRed.png", "pics/BlackKurzRed.png"};
            avatar = avatarArray[random.Next(0, avatarArray.Length)];
            return avatar;
        }
        private string GetEnglishForeName()
        {
            
            string name = string.Empty;
            string[] forenames = {"Oliver", "George", "Noah", "Arthur", "Harry", "Leo", "Muhammad", "Jack", "Charlie", "Oscar", "Jacob", "Henry", "Thomas", "Freddie", "Alfie", "Theo", "William",
                                  "Theodore", "Archie", "Joshua", "Alexander", "James", "Isaac", "Edward", "Lucas", "Tommy", "Finley", "Max", "Logan", "Ethan", "Mohammed", "Teddy", "Benjamin",
                                  "Arlo", "Joseph", "Sebastian", "Harrison", "Elijah", "Adam", "Daniel", "Samuel", "Louie", "Mason", "Reuben", "Albie", "Rory", "Jaxon", "Hugo", "Luca",
                                  "Dylan", "Albert", "David", "Jude", "Frankie", "Roman", "Ezra", "Toby", "Riley", "Carter", "Ronnie", "Frederick", "Gabriel", "Stanley", "Bobby", "Jesse",
                                  "Michael", "Elliot", "Grayson", "Mohammad", "Liam", "Jenson", "Ellis", "Harley", "Harvey", "Jayden", "Jake", "Ralph", "Rowan", "Jasper", "Ollie", "Charles",
                                  "Finn", "Felix", "Caleb", "Chester", "Jackson", "Hudson", "Leon", "Ibrahim", "Ryan", "Blake", "Alfred", "Oakley", "Matthew", "Luke", "Abdoulaye", "Adama", "Cheikhou",
                                  "Diafra", "Idrissa", "Kalidou", "Keita", "Mame", "MBaye", "Moussa", "Salif", "Youssouf", "Alejandro", "Pablo", "Marcos", "Thiago", "Javier", "Antonio", "Jose"};
            name = forenames[rndForeNames.Next(0, forenames.Length)];
            return name;
        }
        private string GetEnglishSureName()
        {
            
            string name = string.Empty;
            string[] surenames = {"Smith", "Jones", "Taylor", "Williams", "Brown", "Davies", "Evans", "Wilson", "Thomas", "Roberts", "Johnson", "Lewis", "Walker", "Robinson", "Wood", "Thompson",
                                  "White", "Watson", "Jackson", "Wright", "Green", "Harris", "Cooper", "King", "Lee", "Martin", "Clarke", "James", "Morgan", "Hughes", "Edwards", "Hill", "Moore",
                                  "Clark", "Harrison", "Scott", "Young", "Morris", "Hall", "Ward", "Turner", "Carter", "Phillips", "Mitchell", "Patel", "Adams", "Campell", "Anderson", "Allen", "Cook",
                                  "Boubacar", "Camara", "Ceesay", "Coulibaly", "Demba", "Diakhate", "Diarra", "Diop", "Sonko", "Fernandez", "Herrera", "Louis", "Juarez", "Suarez", "Juan"};
            name = surenames[rndSureNames.Next(0, surenames.Length)];
            return name;
        }
        
        public void CreatNewFileEngland(string filename)
        {

            using (StreamWriter sw = new StreamWriter(filename, false, Encoding.ASCII))
            {
                manU = CreatTeam(manU, "Manchester Devils",30, 60, 15, 50, 50, 70, 55, 99, 5, 10, 70, 99, "eng");
                lndonClocks = CreatTeam(lndonClocks, "FC London Clocks", 30, 60, 15, 50, 50, 70, 55, 99, 5, 10, 70, 99, "eng");
                chelseaLions = CreatTeam(chelseaLions, "FC Chelsea Lions", 30, 60, 15, 50, 50, 70, 55, 99, 5, 10, 70, 99, "eng");
                liverpoolFlames = CreatTeam(liverpoolFlames, "FC Liverpool Flames", 30, 60, 15, 50, 50, 70, 55, 99, 5, 10, 70, 99, "eng");
                manCitizen = CreatTeam(manCitizen, "FC Manchester Citizen", 30, 60, 15, 50, 50, 70, 55, 99, 5, 10, 70, 99, "eng");
                westHamUnion = CreatTeam(westHamUnion, "FC West Ham Union", 30, 50, 15, 50, 50, 70, 50, 90, 5, 10, 70, 92, "eng");
                wolverhamptonWolves = CreatTeam(wolverhamptonWolves, "Wolves Wolverhampton FC", 30, 50, 15, 50, 50, 70, 50, 90, 5, 10, 70, 90, "eng");
                brightonHoveAlbatros = CreatTeam(brightonHoveAlbatros, "FC Brighton & Hove", 30, 50, 15, 50, 50, 70, 50, 85, 4, 9, 60, 85, "eng");
                tottenHamColdspurs = CreatTeam(tottenHamColdspurs, "FC Tottenham Coldspurs", 30, 50, 15, 50, 50, 70, 50, 90, 5, 10, 60, 90, "eng");
                evertonUnited = CreatTeam(evertonUnited, "FC Everton United", 30, 50, 15, 50, 50, 70, 50, 85, 4, 8, 60, 85, "eng");
                leicesterFoxes = CreatTeam(leicesterFoxes, "FC Leicester Foxes", 30, 50, 15, 50, 50, 70, 50, 85, 4, 8, 60, 85, "eng");
                brentfordNational = CreatTeam(brentfordNational, "National Brentford", 30, 50, 15, 50, 50, 70, 50, 80, 3, 8, 60, 80, "eng");
                crystalPalaceEagles = CreatTeam(crystalPalaceEagles, "Eagles Crystal Palace", 30, 50, 15, 50, 50, 70, 50, 80, 3, 8, 60, 80, "eng");
                southamptonTrees = CreatTeam(southamptonTrees, "FC Southampton Trees", 30, 50, 15, 50, 50, 70, 50, 80, 3, 8, 60, 80, "eng");
                astonVillaGoldenLions = CreatTeam(astonVillaGoldenLions, "Golden Lions Aston Villa", 30, 50, 15, 50, 50, 70, 50, 80, 3, 8, 60, 80, "eng");
                watfordCity = CreatTeam(watfordCity, "Watford City FC", 30, 50, 15, 50, 50, 70, 50, 80, 3, 8, 60, 80, "eng");
                leedsUnion = CreatTeam(leedsUnion, "FC Leeds Union", 30, 50, 15, 50, 50, 70, 50, 80, 3, 8, 60, 80, "eng");
                burnleyStorms = CreatTeam(burnleyStorms, "Burnley Storms", 30, 50, 15, 50, 50, 70, 50, 75, 3, 8, 60, 75, "eng");
                newcastleRoyals = CreatTeam(newcastleRoyals, "Newcastle Royals FC", 30, 50, 15, 50, 50, 70, 50, 75, 3, 8, 60, 75, "eng");
                norwichBirds = CreatTeam(norwichBirds, "Norwich Birds FC", 30, 50, 15, 50, 50, 70, 50, 70, 3, 8, 60, 70, "eng");

                foreach (var player in manU)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                             player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                             player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                             player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);
                }
                foreach (var player in lndonClocks)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in chelseaLions )
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in liverpoolFlames)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in manCitizen)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in westHamUnion)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in wolverhamptonWolves)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in brightonHoveAlbatros)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in tottenHamColdspurs)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in evertonUnited)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in leicesterFoxes)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in brentfordNational)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in crystalPalaceEagles)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in southamptonTrees)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in astonVillaGoldenLions)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in watfordCity)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in leedsUnion)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in burnleyStorms)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in newcastleRoyals)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }
                foreach (var player in norwichBirds)
                {
                    sw.WriteLine(player.ActualClub + "-" + player.Age + "-" + player.Position + "-" + player.GoalKeeping + "-" + player.Attack + "-" + player.Defense + "-" + player.Midfield + "-" +
                            player.Forename + "-" + player.Surname + "-" + player.Form + "-" + player.Size + "-" + player.Weigth + "-" + player.Talent + "-" + player.Moral + "-" +
                            player.BodyStrength + "-" + player.Fitness + "-" + player.Flanks + "-" + player.Header + "-" + player.Passing + "-" + player.Speed + "-" + player.Tactical + "-" +
                            player.Shooting + "-" + player.TechnicSkill + "-" + player.Foot + "-" + player.Strength + "-" + player.Avatar);

                }

            }



        }
        
        public List<Club> LoadFileEngland(string filename)
        {
            manU.Clear();
            lndonClocks.Clear();

            using (StreamReader sr = new StreamReader(filename))
            {
                Player player = new Player();

                string newplayer;
               
                while (!sr.EndOfStream)
                {

                    newplayer = sr.ReadLine();
                    string[] sv = newplayer.Split('-');
                    player = new Player { ActualClub = sv[0], Age = Convert.ToInt32(sv[1]), Position = sv[2], GoalKeeping = Convert.ToInt32(sv[3]), Attack = Convert.ToInt32(sv[4]),
                                          Defense = Convert.ToInt32(sv[5]), Midfield = Convert.ToInt32(sv[6]), Forename = sv[7], Surname = sv[8], Form = Convert.ToInt32(sv[9]), Size = Convert.ToDouble(sv[10]),
                                          Weigth = Convert.ToInt32(sv[11]), Talent = Convert.ToInt32(sv[12]), Moral = Convert.ToInt32(sv[13]), BodyStrength = Convert.ToInt32(sv[14]), Fitness = Convert.ToInt32(sv[15]),
                                          Flanks = Convert.ToInt32(sv[16]), Header = Convert.ToInt32(sv[17]), Passing = Convert.ToInt32(sv[18]), Speed = Convert.ToInt32(sv[19]), Tactical = Convert.ToInt32(sv[20]), 
                                          Shooting = Convert.ToInt32(sv[21]), TechnicSkill = Convert.ToInt32(sv[22]), Foot = sv[23], Strength = Convert.ToInt32(sv[24]), Avatar = sv[25] };
                    if (player.ActualClub == "Manchester Devils")
                        manU.Add(player);
                    if (player.ActualClub == "FC London Clocks")
                        lndonClocks.Add(player);
                    if (player.ActualClub == "FC Chelsea Lions")
                        chelseaLions.Add(player);
                    if (player.ActualClub == "FC Liverpool Flames")
                        liverpoolFlames.Add(player);
                    if (player.ActualClub == "FC Manchester Citizen")
                        manCitizen.Add(player);
                    if (player.ActualClub == "FC West Ham Union")
                        westHamUnion.Add(player);
                    if (player.ActualClub == "Wolves Wolverhampton FC")
                        wolverhamptonWolves.Add(player);
                    if (player.ActualClub == "FC Brighton & Hove")
                        brightonHoveAlbatros.Add(player);
                    if (player.ActualClub == "FC Tottenham Coldspurs")
                        tottenHamColdspurs.Add(player);
                    if (player.ActualClub == "FC Everton United")
                        evertonUnited.Add(player);
                    if (player.ActualClub == "FC Leicester Foxes")
                        leicesterFoxes.Add(player);
                    if (player.ActualClub == "National Brentford")
                        brentfordNational.Add(player);
                    if (player.ActualClub == "Eagles Crystal Palace")
                        crystalPalaceEagles.Add(player);
                    if (player.ActualClub == "FC Southampton Trees")
                        southamptonTrees.Add(player);
                    if (player.ActualClub == "Golden Lions Aston Villa")
                        astonVillaGoldenLions.Add(player);
                    if (player.ActualClub == "Watford City FC")
                        watfordCity.Add(player);
                    if (player.ActualClub == "FC Leeds Union")
                        leedsUnion.Add(player);
                    if (player.ActualClub == "Burnley Storms")
                        burnleyStorms.Add(player);
                    if (player.ActualClub == "Newcastle Royals FC")
                        newcastleRoyals.Add(player);
                    if (player.ActualClub == "Norwich Birds FC")
                        norwichBirds.Add(player);
                }
            }
            //die Englische Liga erzeugen, mit allen teams, daten und Spielern
            //um die Teams aufzurufen und änderungen daran durchzuführen muss das über die league Liste erfolgen
            Leagues le = new Leagues();
            club = le.England(manU, "Manchester Devils", 50000, 3, Brushes.Red, Brushes.Black, Brushes.Blue);
            league.Add(club);
            club = le.England(lndonClocks, "FC London Clocks", 40000, 3, Brushes.Red, Brushes.White, Brushes.Gold);
            league.Add(club);
            club = le.England(chelseaLions, "FC Chelsea Lions", 40000, 3, Brushes.Blue, Brushes.White, Brushes.Black);
            league.Add(club);
            club = le.England(liverpoolFlames, "FC Liverpool Flames", 60000, 4, Brushes.Red, Brushes.Red, Brushes.White);
            league.Add(club);
            club = le.England(manCitizen, "FC Manchester Citizen", 50000, 3, Brushes.Cyan, Brushes.White, Brushes.Black);
            league.Add(club);
            club = le.England(westHamUnion, "FC West Ham Union", 10000, 1, Brushes.DarkRed, Brushes.Cyan, Brushes.Blue);
            league.Add(club);
            club = le.England(wolverhamptonWolves, "Wolves Wolverhampton FC", 8000, 1, Brushes.Orange, Brushes.Black, Brushes.White);
            league.Add(club);
            club = le.England(brightonHoveAlbatros, "FC Brighton & Hove", 0, 0, Brushes.DarkCyan, Brushes.White, Brushes.Yellow);
            league.Add(club);
            club = le.England(tottenHamColdspurs, "FC Tottenham Coldspurs", 30000, 1, Brushes.White, Brushes.Black, Brushes.Blue);
            league.Add(club);
            club = le.England(evertonUnited, "FC Everton United", 10000, 1, Brushes.Blue, Brushes.White, Brushes.Cyan);
            league.Add(club);
            club = le.England(leicesterFoxes, "FC Leicester Foxes", 8000, 0, Brushes.Blue, Brushes.White, Brushes.Gold);
            league.Add(club);
            club = le.England(brentfordNational, "National Brentford", -10000, -1, Brushes.Red, Brushes.White, Brushes.Black);
            league.Add(club);
            club = le.England(crystalPalaceEagles, "Eagles Crystal Palace", 0, 0, Brushes.DarkRed, Brushes.Blue, Brushes.Gold);
            league.Add(club);
            club = le.England(southamptonTrees, "FC Southampton Trees", 0, 0, Brushes.Red, Brushes.Black, Brushes.White);
            league.Add(club);
            club = le.England(astonVillaGoldenLions, "Golden Lions Aston Villa", 20000, 0, Brushes.DarkRed, Brushes.DarkCyan, Brushes.Gold);
            league.Add(club);
            club = le.England(watfordCity, "Watford City FC", 0, -1, Brushes.Yellow, Brushes.Black, Brushes.White);
            league.Add(club);
            club = le.England(leedsUnion, "FC Leeds Union", 0, -1, Brushes.White, Brushes.Yellow, Brushes.Blue);
            league.Add(club);
            club = le.England(burnleyStorms, "Burnley Storms", -20000, -2, Brushes.Red, Brushes.White, Brushes.Black);
            league.Add(club);
            club = le.England(newcastleRoyals, "Newcastle Royals FC", 10000, 0, Brushes.Black, Brushes.White, Brushes.Gold);
            league.Add(club);
            club = le.England(norwichBirds, "Norwich Birds FC", -20000, -2, Brushes.Green, Brushes.Yellow, Brushes.White);
            league.Add(club);
            return league;
        }
      
      
        public List<Player> CreatTeam(List<Player> club, string clubName, int standardMin, int standardMax, int gkstandardMin, int gkstandardMax, int techMin, int techMax, int characterMin, int characterMax, int talentMin, int talentMax, int playerCharMin, int playerCharMax, string country)
        {
            for (int i = 0; i < 23; i++)
            {
                string surename = string.Empty;
                string forename = string.Empty;
                string position = string.Empty;
                int defense = random.Next(standardMin, standardMax);
                int midfield = random.Next(standardMin, standardMax);
                int attack = random.Next(standardMin, standardMax);
                int goalkeeping = random.Next(gkstandardMin, gkstandardMax);
                int bodystrength = random.Next(characterMin, characterMax);
                int tactical = random.Next(characterMin, characterMax);
                int technicskills = random.Next(techMin, techMax);
                int header = random.Next(characterMin, characterMax);
                int shooting = random.Next(standardMin, standardMax);
                int flanks = random.Next(standardMin, standardMax);
                int passing = random.Next(characterMin, characterMax);
                int speed = random.Next(characterMin, characterMax);
                int moral = random.Next(characterMin, characterMax);
                int talent = random.Next(talentMin, talentMax);
                int fitness = random.Next(characterMin, characterMax);
                int form = random.Next(characterMin, characterMax);
                double size = random.NextDouble() * (2.00 - 1.65) + 1.65;
                size = Math.Round(size, 2);
                int weigth = random.Next(65, 85);
                int age = random.Next(16, 35);
                string foot = SetFoot();
                string avatar = GetAvatar();
                if (i >= 0 && i <= 3)
                {
                    position = "TW";
                    goalkeeping = random.Next(playerCharMin, playerCharMax);

                }

                if (i > 3 && i <= 11)
                {
                    position = "V";
                    header = random.Next(playerCharMin, playerCharMax);
                    defense = random.Next(playerCharMin, playerCharMax);
                    tactical = random.Next(playerCharMin, playerCharMax);
                    bodystrength = random.Next(playerCharMin, playerCharMax);
                }


                if (i > 11 && i <= 17)
                {
                    position = "MF";
                    midfield = random.Next(playerCharMin, playerCharMax);
                    tactical = random.Next(playerCharMin, playerCharMax);
                    technicskills = random.Next(playerCharMin, playerCharMax);
                    passing = random.Next(playerCharMin, playerCharMax);
                    shooting = random.Next(playerCharMin, playerCharMax);
                    speed = random.Next(playerCharMin, playerCharMax);
                }
                if (i > 17 && i <= 22)
                {
                    position = "ST";
                    attack = random.Next(playerCharMin, playerCharMax);
                    tactical = random.Next(playerCharMin, playerCharMax);
                    shooting = random.Next(playerCharMin, playerCharMax);
                    header = random.Next(playerCharMin, playerCharMax);
                    speed = random.Next(playerCharMin, playerCharMax);
                    passing = random.Next(playerCharMin, playerCharMax);
                }
                if (country == "eng")
                {
                    forename = GetEnglishForeName();
                    surename = GetEnglishSureName();
                }
                if (surename == "Boubacar" || surename == "Camara" || surename == "Ceesay" || surename == "Coulibaly" || surename == "Demba" || surename == "Diakhate" || surename == "Diarra"
                   || surename == "Diop" || surename == "Sonko")
                {
                    avatar = "pics/BlackRed.png";
                }
                player = new Player
                {
                    ActualClub = clubName,
                    Age = age,
                    Position = position,
                    GoalKeeping = goalkeeping,
                    Attack = attack,
                    Defense = defense,
                    Midfield = midfield,
                    Forename = forename,
                    Surname = surename,
                    Form = form,
                    Size = size,
                    Weigth = weigth,
                    Talent = talent,
                    Moral = moral,
                    BodyStrength = bodystrength,
                    Fitness = fitness,
                    Flanks = flanks,
                    Header = header,
                    Passing = passing,
                    Speed = speed,
                    Tactical = tactical,
                    Shooting = shooting,
                    TechnicSkill = technicskills,
                    Foot = foot,
                    Avatar = avatar
                };
                player.Strength = player.OverallStrength();
                club.Add(player);
            }

            return club;
        }
       
    }
}
