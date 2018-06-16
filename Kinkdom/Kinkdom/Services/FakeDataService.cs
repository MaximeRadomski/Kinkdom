using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Kinkdom.Models;
using Kinkdom.Services.Interfaces;

namespace Kinkdom.Services
{
    public class FakeDataService : IFakeDataService
    {
        private List<Category> _categories;
        private List<Product> _products;

        public FakeDataService()
        {
            InitializeFakeData();
        }

        private void InitializeFakeData()
        {
            _categories = new List<Category>
            {
                new Category { Id = 0, Title = "Toys", ImagePath = "MenuIcon01.png"},
                new Category { Id = 1, Title = "Restraints", ImagePath = "MenuIcon02.png"},
                new Category { Id = 2, Title = "Furnitures", ImagePath = "MenuIcon03.png"},
                new Category { Id = 3, Title = "Outfits", ImagePath = "MenuIcon04.png"},
                new Category { Id = 4, Title = "Practices", ImagePath = "MenuIcon05.png"},
                new Category { Id = 5, Title = "About", ImagePath = "MenuIcon06.png"},
                new Category { Id = 6, Title = "Favorites", ImagePath = "Favorite04.png"}
            };
            _products = new List<Product>
            {
                new Product {Name = "Anal Hook",
                    Desc01 = " - Designed to hold your partner in place, most of the time with the back arched.\n - The ball/plug part is inserted in the anus, and the ring at the end of the hook is often bonded to a wrist restraint device, or a collar thanks to a rope or a chain.",
                    Desc02 = " - This toy is made for a hole not lubricating naturally, understand here that lubricant is more than advised.\n - Just as a butt plug, the vaginal penetration while having the hook in the anus is very effective, and even more considering the fact that you can easily move the ball/plug part of the hook with the extern handle.",
                    Desc03 = " - The hook can also be suspended from the ceiling with a rope, but be careful about suspension as it could lead to devastating damages if your partner slip or fall on the floor...\n - This toy is advised for people with some experience and knowing the basic of anal stimulation. The pressure caused by the ball/plug part, which can go very deep, might be unpleasant for a beginner.",
                    Category01 = 0,
                    Category02 = 1,
                    Image01 = "AnalHook01.png",
                    Level = 1},
                new Product {Name = "Armbinder",
                    Desc01 = " - Designed to bind the arms to each other. It is a useful restraint device if you are aiming for a total immobilization of the arms.\n - It exists as a monoglove, or a serie of straps and handcuffs placed on the arms at various points such as the wrists and elbows.",
                    Desc02 = " - It can take some time to prepare and set an armbinder, try to set all the other restraint devices before in order to save some time, some blood flow and movement for your partner.\n - Wash it often, a monoglove can be hot, sweaty and smelly.\n - You can usually find a metal ring at the end of monogloves, useful to bind to another restraint device.\n - Monogloves can slide easily if not tied tight. If you are not flexible enough, try a model with shoulder strap to prevent it from sliding.",
                    Desc03 = " - Armbinders can cause problems with the soft tissues of the shoulder joints and with the circulation and innervation of the arms and hands. If you are not flexible enough, tight it less.",
                    Category01 = 1,
                    Category02 = 3,
                    Image01 = "Armbinder01.png",
                    Level = 1},
                new Product {Name = "Ball Gag",
                    Desc01 = " - Designed to keep the mouth open, to render the speech unintelligible, and to drool.\n - It goes from the simple ball with a strap, to the horse harness with eye patch and more.",
                    Desc02 = " - If you have trouble breathing with a plain ball, lot of models have holes within the ball.\n - Don't be afraid to drool, trying to swallow your saliva constantly can give you jaw pain.\n - Wash it before first use as it can still have a weird taste, especially for silicone balls.",
                    Desc03 = " - Try to use models with a good quality strap around your head, bad quality leather or plastic can leave you with pain and marks on the very sides of your lips. But it might be a kink as well !\n - Try to choose something else than \"Marmelade\" as a safe word, you might have trouble to say it properly with a ball in your mouth.",
                    Category01 = 1,
                    Image01 = "BallGag01.png",
                    Level = 0},
                new Product {Name = "Bit Gag",
                    Desc01 = " - This product is a different version of the ball gag.\n - Designed to keep the mouth open, to render the speech unintelligible, and to drool.",
                    Desc02 = " - You shouldn't have breathing troubles like with a ball because the bit gag does not enter as deep in your mouth.\n - Don't be afraid to drool, trying to swallow your saliva constantly can give you jaw pain.\n - Wash it before first use as it can still have a weird taste, especially for silicone bit gag.",
                    Desc03 = " - Try to use models with a good quality strap around your head, bad quality leather or plastic can leave you with pain and marks on the very sides of your lips. But it might be a kink as well !\n - Try to choose something else than \"Marmelade\" as a safe word, you might have trouble to say it properly with this toy in your mouth.",
                    Category01 = 1,
                    Image01 = "BitGag01.png",
                    Level = 0},
                new Product {Name = "Bondage Bed",
                    Desc01 = " - Designed to receive a mattress and to bind a lot of bondage tools to it, like ropes, chains, handcuffs and more...\n - Some even have a cage under the mattress, a Bondage Yoke or a Saint Andrew's Cross.",
                    Desc02 = " - As a lot of furnitures, this kind of product is very expensive, and often have american mattress sizes. So be sure of what you are buying !\n - When the constructor says you need to be at least two to build it, it actually means that you really need to be at least two to build it.",
                    Desc03 = " - Not all beds allow heavyweight suspension, try not to destroy your bed and your back at the same time.",
                    Category01 = 2,
                    Image01 = "BondageBed01.png",
                    Level = 2},
                new Product {Name = "Bondage Belt",
                    Desc01 = " - Designed to bind all sort of of things to the waist.\n - Belts are most of the time large enough to have multiples rings and straps. Some are even closer to corsets than to belts.",
                    Desc02 = " - Lot of tools can be equipped or bind to belts. Handcuffs, chains, ropes, armbinders, or even womanizer. Be creative !",
                    Desc03 = " - You might have an increased heartbeat while wearing this in action, try not to wear it too tight if you can't bear it.",
                    Category01 = 1,
                    Category02 = 3,
                    Image01 = "BondageBelt01.png",
                    Level = 0},
                new Product {Name = "Bondage Cuffs",
                    Image01 = "BondageCuffs01.png"
                },
                new Product {Name = "Bondage Harness",
                    Image01 = "BondageHarness01.png",
                    Image02 = "BondageHarness02.png"
                },
                new Product {Name = "Bondage Hood",
                    Image01 = "BondageHood01.png"
                },
                new Product {Name = "Bondage Mittens",
                    Image01 = "BondageMittens01.png"
                },
                new Product {Name = "Bondage Tape",
                    Image01 = "BondageTape01.png"
                },
                new Product {Name = "Breast Binder",
                    Image01 = "BreastBinder01.png"
                },
                new Product {Name = "Butt Plug",
                    Desc01 = " - Designed to be inserted into the rectum. The anal cavity having a lot of nerves, it is a good toy to enjoy anal pleasure.\n - If you have a penis, you can use it to stimulate your prostate.\n - If you have a vagina, you can use it to fill the anal cavity and therefore making the vagina tighter.",
                    Desc02 = " - This toy is made for a hole not lubricating naturally, understand here that lubricant is more than advised.\n - But be careful not to use silicone lubricant with a silicone toy ! It melts !!\n - The membrane between the vagina and the rectum being very small, the vaginal penetration while having a butt plug is stimulating both of your magick holes.\n - Use a pear enema if you don't want a smelly/poopy toy after utilisation.\n - Metal, glass and ABS hard plastic butt plugs don't smell, don't keep residuals and are easy to wash !",
                    Desc03 = " - Butt plugs have a flanged end to prevent them being lost inside the rectum, do not use anything as a butt plug if it doesn't have that part.\n - Do not start too big, your sphincters have to be trained before being able to handle tank shells.",
                    Category01 = 0,
                    Category02 = 1,
                    Image01 = "ButtPlug01.png",
                    Level = 1},
                new Product {Name = "Chastity Belt",
                    Image01 = "ChastityBelt01.png"
                },
                new Product {Name = "Cock Rings",
                    Image01 = "CockRings01.png"
                },
                new Product {Name = "Collar",
                    Image01 = "Collar01.png"
                },
                new Product {Name = "Corset",
                    Image01 = "Corset01.png"
                },
                new Product {Name = "Dental Forceps",
                    Image01 = "DentalForceps01.png"
                },
            };
        }

        public async Task<List<Category>> SetAllCategories()
        {
            await Task.CompletedTask;
            return _categories;
        }

        public async Task<int> CountAllCategories()
        {
            await Task.CompletedTask;
            return _categories.Count;
        }

        public async Task<List<Product>> SetAllProducts()
        {
            await Task.CompletedTask;
            return _products;
        }

        public async Task<int> CountAllProducts()
        {
            await Task.CompletedTask;
            return _products.Count;
        }
    }
}