using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFrench.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any record.
                if (context.ApplicationUserType.Any())
                {
                    return;   // DB has been seeded
                }

                ////////////////////////Seeding ApplicationUserType Table/////////////////////////////////////////
                context.ApplicationUserType.AddRange(
                    new ApplicationUserType
                    {
                        UserType = "Student"
                    },

                    new ApplicationUserType
                    {
                        UserType = "Parent"
                    },
                    new ApplicationUserType
                    {
                        UserType = "Teacher"
                    },
                    new ApplicationUserType
                    {
                        UserType = "Principal"
                    },
                    new ApplicationUserType
                    {
                        UserType = "SchoolBoardMember"
                    },
                    new ApplicationUserType
                    {
                        UserType = "Admin1"
                    },
                    new ApplicationUserType
                    {
                        UserType = "Admin2"
                    }
                );
                context.SaveChanges();
                ////////////////////////Seeding ApplicationUser Table/////////////////////////////////////////
             /*   context.ApplicationUser.AddRange(
                    new ApplicationUser
                    {
                        UserName = "Vany",
                        
                    },
                    new ApplicationUser
                    {
                        UserName = "Victory",
                    }
                    );
                context.SaveChanges();*/
                ////////////////////////Seeding Level Table/////////////////////////////////////////
                var levels = new Level[]
               {
                new Level { Title = "Pre Level" },
                new Level { Title = "Level 1" },
                new Level { Title = "Level 2" },
                new Level { Title = "Level 3" },
                new Level { Title = "Level 4" },
                new Level { Title = "Level 5" },
                new Level { Title = "Level 6" },
                new Level { Title = "Level 7" },
                new Level { Title = "Level 8" }

               };                
                foreach (Level l in levels)
                {
                    context.Levels.Add(l);
                    
                }
                context.SaveChanges();

                ////////////////////////Seeding Topic Table/////////////////////////////////////////
                var topics = new Topic[]
                {
                    /*PreLevel and up */
                new Topic { TitleFrench = "L'alphabet", TitleEnglish = "French Alphabet" },
                new Topic { TitleFrench = "Mes parties du corps",TitleEnglish = "My Parts of the body"},
                new Topic { TitleFrench = "Ma famille",TitleEnglish = "My Family"},
                new Topic { TitleFrench = "Mes Proches",TitleEnglish = "My Relatives"},
                new Topic { TitleFrench = "La nourriture",TitleEnglish ="Food"},
                new Topic { TitleFrench = "Les couleurs", TitleEnglish = "Colours" },
                new Topic { TitleFrench = "Les nombres",TitleEnglish = "Numbers" },
                new Topic { TitleFrench = "Les formes et les solides",TitleEnglish = "Shapes and Solids"},
                new Topic { TitleFrench = "Les animaux",TitleEnglish = "Animals"},
                new Topic { TitleFrench = "À l'école",TitleEnglish = "At school"},
                new Topic { TitleFrench = "Les accessoires",TitleEnglish = "Accessories"},
                    /*Level 1 and up */
                new Topic { TitleFrench = "Les jours de la semaine", TitleEnglish = "The Days of the Week" },
                new Topic { TitleFrench = "Les mois de l'année",TitleEnglish = "The Months of the Year"},
                new Topic { TitleFrench = "Les saisons", TitleEnglish = "The Seasons" },
                new Topic { TitleFrench = "Le temps", TitleEnglish = "The Time" },
                new Topic { TitleFrench = "La météo",TitleEnglish = "The Weather"},
                new Topic { TitleFrench = "Les vêtements",TitleEnglish = "Clothing"},
                new Topic { TitleFrench = "Les métier",TitleEnglish = "Professions"},
                new Topic { TitleFrench = "La nature", TitleEnglish = "Nature" },
                new Topic { TitleFrench = "Chez moi",TitleEnglish = "At my home" },
                new Topic { TitleFrench = "Les émotions", TitleEnglish = "Feelings" },
                new Topic { TitleFrench = "Les verbes", TitleEnglish = "Verbs" },
                 /*Level 2 and up */
                new Topic { TitleFrench = "Mots mathématiques",TitleEnglish = "Mathematics words"},
                new Topic { TitleFrench = "Les directions",TitleEnglish = "Directions"},
                new Topic { TitleFrench = "Des pays",TitleEnglish = "Countries"},
                new Topic { TitleFrench = "les adjectifs possessifs",TitleEnglish = "Possessive Adjectives"}
                };
                foreach (Topic t in topics)
                {
                    context.Topics.Add(t);
                }
                context.SaveChanges();
                ////////////////////////Seeding TopicLevel Table///////////////////////////////////
                var TopicLevels = new TopicLevel[]
               {

                /* Pre Level Topics */
                new TopicLevel {
                    TopicID = topics.Single(c => c.TitleFrench == "L'alphabet" ).ID,
                    LevelID = levels.Single(i => i.Title == "Pre Level").ID
                    },
                new TopicLevel {
                    TopicID = topics.Single(c => c.TitleFrench == "Mes parties du corps" ).ID,
                    LevelID = levels.Single(i => i.Title == "Pre Level").ID
                    },
                new TopicLevel {
                    TopicID = topics.Single(c => c.TitleFrench == "Ma famille" ).ID,
                    LevelID = levels.Single(i => i.Title == "Pre Level").ID
                    },
                new TopicLevel {
                    TopicID = topics.Single(c => c.TitleFrench == "Mes Proches" ).ID,
                    LevelID = levels.Single(i => i.Title == "Pre Level").ID
                    },
                new TopicLevel {
                    TopicID = topics.Single(c => c.TitleFrench == "La nourriture" ).ID,
                    LevelID = levels.Single(i => i.Title == "Pre Level").ID
                    },
                new TopicLevel {
                    TopicID = topics.Single(c => c.TitleFrench == "Les couleurs" ).ID,
                    LevelID = levels.Single(i => i.Title == "Pre Level").ID
                    },
                new TopicLevel {
                    TopicID = topics.Single(c => c.TitleFrench == "Les nombres" ).ID,
                    LevelID = levels.Single(i => i.Title == "Pre Level").ID
                    },
                new TopicLevel {
                    TopicID = topics.Single(c => c.TitleFrench == "Les formes et les solides" ).ID,
                    LevelID = levels.Single(i => i.Title == "Pre Level").ID
                    },
                new TopicLevel {
                    TopicID = topics.Single(c => c.TitleFrench == "Les animaux" ).ID,
                    LevelID = levels.Single(i => i.Title == "Pre Level").ID
                    },
                new TopicLevel {
                    TopicID = topics.Single(c => c.TitleFrench == "À l'école" ).ID,
                    LevelID = levels.Single(i => i.Title == "Pre Level").ID
                    },
                new TopicLevel {
                    TopicID = topics.Single(c => c.TitleFrench == "Les accessoires" ).ID,
                    LevelID = levels.Single(i => i.Title == "Pre Level").ID
                    },
                /* Level 1 Topics */
                new TopicLevel {
                    TopicID = topics.Single(c => c.TitleFrench == "L'alphabet" ).ID,
                    LevelID = levels.Single(i => i.Title == "Level 1").ID
                    },
                new TopicLevel {
                    TopicID = topics.Single(c => c.TitleFrench == "Les jours de la semaine" ).ID,
                    LevelID = levels.Single(i => i.Title == "Level 1").ID
                    },
                new TopicLevel {
                    TopicID = topics.Single(c => c.TitleFrench == "Les jours de la semaine" ).ID,
                    LevelID = levels.Single(i => i.Title == "Level 2").ID
                    },


                  /* Level 2 Topics */
                  /* Level 3 Topics */
                  /* Level 4 Topics */
                  /* Level 5 Topics */
                  /* Level 6 Topics */
                  /* Level 7 Topics */
                  /* Level 8 Topics */
              };

                foreach (TopicLevel tl in TopicLevels)
                {
                    context.TopicLevel.Add(tl);
                }
                context.SaveChanges();
                ////////////////////////Seeding Exercise Table/////////////////////////////////////////
                var exercises = new Exercise[]
                {
                new Exercise { TitleFrench = "Trouver le jour ouvrable correct (en anglais).", TitleEnglish = "Find the correct  Weekday (English)." ,
                        TopicID = topics.Single(c => c.TitleFrench == "Les jours de la semaine" ).ID
                },
                new Exercise { TitleFrench = "Trouver le jour de semaine correct (Français).", TitleEnglish = "Find the correct  Weekday (French)." ,
                        TopicID = topics.Single(c => c.TitleFrench == "Les jours de la semaine" ).ID
                },

                };
                foreach (Exercise e in exercises)
                {
                    context.Exercise.Add(e);
                }
                context.SaveChanges();

                ////////////////////////Seeding Difficulty Table///////////////////////////////////
                var dificulties = new Difficulty[]
               {
                new Difficulty { DifficultyLevel = "Easy", Points = 5},
                new Difficulty { DifficultyLevel = "Medium", Points = 7 },
                new Difficulty { DifficultyLevel = "Hard", Points = 8 },
               };
                foreach (Difficulty d in dificulties)
                {
                    context.Difficulty.Add(d);
                }
                context.SaveChanges();
                ////////////////////////Seeding the Question Table/////////////////////////////////////////
                var questions = new Question[]
                {
                new Question { QuestionFrench = "Quelle est la bonne Français Word pour le mot anglais 'Wednesday'?",
                    QuestionEnglish = "What is the correct French Word for “Wednesday”?",
                    ExerciseID = exercises.Single(c => c.TitleFrench == "Trouver le jour ouvrable correct (en anglais)." ).ID,
                    DifficultyID = dificulties.Single(c => c.DifficultyLevel == "Easy").ID
                },
                new Question { QuestionFrench = "Quelle est la bonne Français Word pour le mot anglais 'Friday'?",
                    QuestionEnglish = "What is the correct French Word for “Friday”?",
                    ExerciseID = exercises.Single(c => c.TitleFrench == "Trouver le jour ouvrable correct (en anglais)." ).ID,
                    DifficultyID = dificulties.Single(c => c.DifficultyLevel == "Easy").ID
                },
                new Question { QuestionFrench = "Quel jour vient après vendredi ?",
                    QuestionEnglish = "Which day is comes after “Friday”?",
                    ExerciseID = exercises.Single(c => c.TitleFrench == "Trouver le jour ouvrable correct (en anglais)." ).ID,
                    DifficultyID = dificulties.Single(c => c.DifficultyLevel == "Medium").ID
                },
                new Question { QuestionFrench = "Quel jour vient après mercredi?",
                    QuestionEnglish = "Which day is comes after “Wednesday”?",
                    ExerciseID = exercises.Single(c => c.TitleFrench == "Trouver le jour ouvrable correct (en anglais)." ).ID,
                    DifficultyID = dificulties.Single(c => c.DifficultyLevel == "Medium").ID
                },
                new Question { QuestionFrench = "Quel jour est avant mercredi?",
                    QuestionEnglish = "Which day is comes before “Wednesday”?",
                    ExerciseID = exercises.Single(c => c.TitleFrench == "Trouver le jour ouvrable correct (en anglais)." ).ID,
                    DifficultyID = dificulties.Single(c => c.DifficultyLevel == "Hard").ID
                },
                new Question { QuestionFrench = "Quel jour est avant vendredi?",
                    QuestionEnglish = "Which day is comes before “Friday”?",
                    ExerciseID = exercises.Single(c => c.TitleFrench == "Trouver le jour ouvrable correct (en anglais)." ).ID,
                    DifficultyID = dificulties.Single(c => c.DifficultyLevel == "Hard").ID
                },

                };
                foreach (Question q in questions)
                {
                    context.Question.Add(q);
                }
                context.SaveChanges();
                ////////////////////////Seeding the QuestionLevel Table/////////////////////////////////////////
                var questionLevels = new QuestionLevel[]
                {
                new QuestionLevel {
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quelle est la bonne Français Word pour le mot anglais 'Wednesday'?" ).ID,
                    LevelID = levels.Single(i => i.Title == "Level 1").ID

                },
                new QuestionLevel {
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quelle est la bonne Français Word pour le mot anglais 'Wednesday'?" ).ID,
                    LevelID = levels.Single(i => i.Title == "Level 2").ID
                },
                new QuestionLevel {
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quelle est la bonne Français Word pour le mot anglais 'Friday'?" ).ID,
                    LevelID = levels.Single(i => i.Title == "Level 1").ID
                },
                new QuestionLevel {
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour vient après vendredi ?" ).ID,
                    LevelID = levels.Single(i => i.Title == "Level 1").ID
                },
                new QuestionLevel {
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour vient après mercredi?" ).ID,
                    LevelID = levels.Single(i => i.Title == "Level 1").ID
                },
                new QuestionLevel {
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour est avant mercredi?" ).ID,
                    LevelID = levels.Single(i => i.Title == "Level 1").ID
                },
                new QuestionLevel {
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour est avant vendredi?" ).ID,
                    LevelID = levels.Single(i => i.Title == "Level 1").ID
                },

                };
                foreach (QuestionLevel ql in questionLevels)
                {
                    context.QuestionLevel.Add(ql);
                }
                context.SaveChanges();
                ////////////////////////Seeding the Answer Table/////////////////////////////////////////
                var answers = new Answer[]
                {
                    //Q1
                new Answer {
                    AnswerText = "mercredi",
                    Status = true,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quelle est la bonne Français Word pour le mot anglais 'Wednesday'?" ).ID,
                       },
                new Answer {
                    AnswerText = "mardi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quelle est la bonne Français Word pour le mot anglais 'Wednesday'?" ).ID,
                       },
                new Answer {
                    AnswerText = "lundi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quelle est la bonne Français Word pour le mot anglais 'Wednesday'?" ).ID,
                       },
                new Answer {
                    AnswerText = "samedi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quelle est la bonne Français Word pour le mot anglais 'Wednesday'?" ).ID,
                       },
                //Q2
                new Answer {
                    AnswerText = "vendredi",
                    Status = true,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quelle est la bonne Français Word pour le mot anglais 'Friday'?").ID,
                       },
                new Answer {
                    AnswerText = "mardi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quelle est la bonne Français Word pour le mot anglais 'Friday'?" ).ID,
                       },
                new Answer {
                    AnswerText = "lundi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quelle est la bonne Français Word pour le mot anglais 'Friday'?" ).ID,
                       },
                new Answer {
                    AnswerText = "samedi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quelle est la bonne Français Word pour le mot anglais 'Friday'?" ).ID,
                       },
                //Q3
                new Answer {
                    AnswerText = "samedi",
                    Status = true,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour vient après vendredi ?" ).ID,
                       },
                new Answer {
                    AnswerText = "mardi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour vient après vendredi ?" ).ID,
                       },
                new Answer {
                    AnswerText = "lundi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour vient après vendredi ?" ).ID,
                       },
                new Answer {
                    AnswerText = "mercredi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour vient après vendredi ?" ).ID,
                       },
                //Q4
                
                new Answer {
                    AnswerText = "jeudi",
                    Status = true,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour vient après mercredi?" ).ID,
                       },
                new Answer {
                    AnswerText = "mardi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour vient après mercredi?" ).ID,
                       },
                new Answer {
                    AnswerText = "lundi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour vient après mercredi?" ).ID,
                       },
                new Answer {
                    AnswerText = "samedi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour vient après mercredi?" ).ID,
                       },
                //Q5
                
                new Answer {
                    AnswerText = "mardi",
                    Status = true,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour est avant mercredi?" ).ID,
                       },
                new Answer {
                    AnswerText = "mercredi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour est avant mercredi?" ).ID,
                       },
                new Answer {
                    AnswerText = "lundi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour est avant mercredi?" ).ID,
                       },
                new Answer {
                    AnswerText = "samedi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour est avant mercredi?" ).ID,
                       },
                //Q6
                
                new Answer {
                    AnswerText = "jeudi",
                    Status = true,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour est avant vendredi?").ID,
                       },
                new Answer {
                    AnswerText = "mardi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour est avant vendredi?" ).ID,
                       },
                new Answer {
                    AnswerText = "lundi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour est avant vendredi?" ).ID,
                       },
                new Answer {
                    AnswerText = "samedi",
                    Status = false,
                    QuestionID = questions.Single(c => c.QuestionFrench == "Quel jour est avant vendredi?" ).ID,
                       },
                };
                foreach (Answer a in answers)
                {
                    context.Answer.Add(a);
                }
                context.SaveChanges();
                ////////////////////////Seeding ApplicationUserType Table///////////////////////////////////
                ///////////////////////////Seeding ApplicationUserType Table///////////////////////////////////
                ///////////////////////////Seeding ApplicationUserType Table///////////////////////////////////
                ///////////////////////////Seeding ApplicationUserType Table///////////////////////////////////
                ///////////////////////////Seeding ApplicationUserType Table///////////////////////////////////
                ///////////////////////////Seeding ApplicationUserType Table///////////////////////////////////
                ///////////////////////////Seeding ApplicationUserType Table///////////////////////////////////
                ///////////////////////////Seeding ApplicationUserType Table///////////////////////////////////
                ///////////////////////////Seeding ApplicationUserType Table///////////////////////////////////

            }

        }
    }
}
