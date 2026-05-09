namespace hr_team.Models
{
    public class Skill
    {
        public Skill(int id, int java, int c, int c_plus_plus, int python, int assembly, int c_sharp, int database_design, int english_language, int russian_language, int german_language, int candidate_id)
        {
            this.id = id;
            this.java = java;
            this.c = c;
            this.c_plus_plus = c_plus_plus;
            this.python = python;
            this.assembly = assembly;
            this.c_sharp = c_sharp;
            this.database_design = database_design;
            this.english_language = english_language;
            this.russian_language = russian_language;
            this.german_language = german_language;
            this.candidate_id = candidate_id;
        }

        private int id { get; set; }
        private int java { get; set; }
        private int c { get; set; }
        private int c_plus_plus { get; set; }
        private int python { get; set; }
        private int assembly { get; set; }
        private int c_sharp { get; set; }
        private int database_design { get; set; }
        private int english_language { get; set; }
        private int russian_language { get; set; }
        private int german_language { get; set; }
        private int candidate_id { get; set; }

    }
}
