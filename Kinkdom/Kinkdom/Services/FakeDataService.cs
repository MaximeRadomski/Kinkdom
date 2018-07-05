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
                    Desc01 = " - Designed to keep the mouth open, to render the speech unintelligible, and to drool.\n - It goes from the simple ball with a strap, to the horse harness with eye patch and more.\n - The third image is called a Bit Gag and has a bone instead of the ball.",
                    Desc02 = " - If you have trouble breathing with a plain ball, lot of models have holes within the ball.\n - Don't be afraid to drool, trying to swallow your saliva constantly can give you jaw pain.\n - Wash it before first use as it can still have a weird taste, especially for silicone balls.",
                    Desc03 = " - Try to use models with a good quality strap around your head, bad quality leather or plastic can leave you with pain and marks on the very sides of your lips. But it might be a kink as well !\n - Try to choose something else than \"Marmelade\" as a safe word, you might have trouble to say it properly with a ball in your mouth.",
                    Category01 = 1,
                    Image01 = "BallGag01.png",
                    Image02 = "BallGag02.png",
                    Image03 = "BitGag01.png",
                    Level = 0},
                new Product {Name = "Bondage Bed",
                    Desc01 = " - Designed to receive a mattress and to bind a lot of bondage tools to it, like ropes, chains, handcuffs and more...\n - Some even have a cage under the mattress, a Bondage Yoke or a Saint Andrew's Cross.",
                    Desc02 = " - As a lot of furnitures, this kind of product is very expensive, and often have american mattress sizes. So be sure of what you are buying !\n - When the constructor says you need to be at least two to build it, it actually means that you really need to be at least two to build it.",
                    Desc03 = " - Not all beds allow heavyweight suspension, try not to destroy your bed and your back at the same time.",
                    Category01 = 2,
                    Image01 = "BondageBed01.png",
                    Level = 2},
                new Product {Name = "Belt",
                    Desc01 = " - Designed to bind all sort of of things to the waist.\n - Belts are most of the time large enough to have multiples rings and straps. Some are even closer to corsets than to belts.",
                    Desc02 = " - Lot of tools can be equipped or bind to belts. Handcuffs, chains, ropes, armbinders, or even womanizer. Be creative !",
                    Desc03 = " - Bad material quality can chafe and even hurt at some point. Take care of the quality of the product you're buying.\n - You might have an increased heartbeat while wearing this in action, try not to wear it too tight if you can't bear it.\n - If you are going for the metal one, be sure to have the appropriate size to your body.",
                    Category01 = 1,
                    Category02 = 3,
                    Image01 = "BondageBelt01.png",
                    Level = 0},
                new Product {Name = "Cuffs",
                    Desc01 = " - Designed to tie two \"columns\" to each others. Those \"columns\" are often wrists and ankles, but think about all the possibilities such as chair legs, bed legs, tables legs, your legs (why not), necklaces, anal hooks, or even electric poles in the street for the bravests !",
                    Desc02 = " - Police metal cuffs are the most commonly known, but understand that they are not very confortable and are more for restraint and masochist pleasure. But some have some fur or leather in it to make it bearable for sensibles wrists.\n - Leather or fake leather ones are way more confortables and can take multiple forms and shape parts of your body, but are of course more expensive.\n - Large metal ones (like in the picture) are the best way to ensure a total control of your partner. They are literally unbrekable and usually need a key or a screwdriver to be opened. But they are like big jewels and therefore very expensive as well. Be sure of the size you need before buying it !",
                    Desc03 = " - Keeping a good blood flow is important, try not to tighten your cuffs too much.\n - Suspension is possible with special handcuffs, do not try suspension with any handcuffs as it could damage your material and your wrists !\n - Handcuffs can easily leave you with marks on the skin, it's a kink, but be warned.",
                    Category01 = 1,
                    Image01 = "BondageCuffs01.png",
                    Level = 1
                },
                new Product {Name = "Harness",
                    Desc01 = " - A harness consists of multiple leather stripes and metal rings, fitting the torso and even some members on more complex models.\n - Most of the rings are made to link the straps together, but some models have specific rings made to be attached to any restraint device.",
                    Desc02 = " - Just as the Bondage Belt, lot of tools can be equipped or bind to a harness. Handcuffs, chains, ropes, etc. Be creative !\n - Just as Shibari, wearing it under clothes in public can be very exciting and adds its own dimension to the foreplay.",
                    Desc03 = " - Bad material quality can chafe and even hurt at some point. Take care of the quality of the product you're buying.\n - You might have an increased heartbeat while wearing this in action, try not to wear it too tight if you can't bear it.",
                    Category01 = 3,
                    Category02 = 1,
                    Image01 = "BondageHarness01.png",
                    Image02 = "BondageHarness02.png",
                    Level = 0
                },
                new Product {Name = "Hood & Mask",
                    Desc01 = " - Hoods and masks can be only aesthetic or fulfil different purposes like breathing restriction, depersonalization and sensory deprivation.\n - It goes from the simple latex hood to your granddaddy's nazi gas mask !",
                    Desc02 = " - Start by testing cheap models if you are not sure of your head size. Not all materials are flexible !\n - If you have long hair, you can pin it in a very loose very flat bun either at the top of your head or the nape of your neck.\n - Some models have holes on the sides or the back letting your hair going through.",
                    Desc03 = " - Be very careful when it comes about breathing restriction. Full enclosure hoods might be fun, but dangerous as well. The use of a safe word is highly recommended here !",
                    Category01 = 1,
                    Category02 = 3,
                    Image01 = "BondageHood01.png",
                    Level = 1
                },
                new Product {Name = "Mittens",
                    Desc01 = " - Designed to prevent the wearer from grasping anything, usually made of stiff material, mittens are made to cause discomfort to the wearer.\n - Some models are long gloves that can going up to the shoulder, and usually have rings over the arm in order to be used like an armbinder.",
                    Desc02 = " - You can find a metal ring at the end of many models, useful to bind to another restraint device.\n - Into furry fetish ? A large amount of animals paws exist to fulfil your desires !",
                    Desc03 = " - Because they aren't made of flexible material, you can easily damage your wrists on the most rigid models if you put too much weight on them.",
                    Category01 = 1,
                    Category02 = 3,
                    Image01 = "BondageMittens01.png",
                    Level = 0
                },
                new Product {Name = "Bondage Tape",
                    Desc01 = " - Designed to tie and bind pretty much anything, tape can also be used to cover holes, to wrap parts of the body, etc...\n - Regular tape has an adhesive face that can adhere to skin. But most often, bondage tape adheres only to itself.",
                    Desc02 = " - If the tape is applied relatively flat on the body, the risk of losing circulation is minimal.\n - Tape can leave a bad smell and a very sticky skin, a shower is more than advised after using some.",
                    Desc03 = " - Be careful of your hairy zones. Strong adhesive tape can leave you with pain while removing it, and not so much hairs left.\n - Tape can easily twist tight, becoming like plastic string and increasing the possibility of pinching and a loss of circulation.",
                    Category01 = 1,
                    Image01 = "BondageTape01.png",
                    Level = 1
                },
                new Product {Name = "Yoke",
                    Desc01 = " - Designed to keep the neck and wrists to a restraining position, or on some models, the wrists and ankles tied together.\n - Yokes are used when simple ropes or cuffs offer too much mobility and/or the bottom tends to move too much.",
                    Desc02 = " - Be prepared of the size and weight yokes can represent! Those in wood or metal can be exhausting for your arms or shoulders.\n - If it's a fixed yoke, on a bondage bed for example, your initial position should be as comfy as possible. We are talking about a restraining device after all, but a bad position can leave you for example with a loss of your strengh in your legs, which can be very unpleasant and exhausting.",
                    Desc03 = " - Using a yoke can be surprising at first. Ff you are used to cuffs or ropes, you will find here a much more rigid restraining device. Therefore, try not to move or resist the yoke as much as you would do with cuffs or ropes, it can damages your wrists and neck.",
                    Category01 = 1,
                    Category02 = 2,
                    Image01 = "Yoke01.png",
                    Level = 1
                },
                new Product {Name = "Breast Binder",
                    Desc01 = " - Designed to exercise a pression over the breast.\n - Some are made to hold the breasts tight  together and have a pression coming from the sides. Some to flaten them against the body, those models can have little spikes pushing around or on the nipples. Some to go around each breast or to flaten each breast over itself.",
                    Desc02 = " - A breast binder going around the chest can easily fall on small chests if not tied tight enough. But tightening it might cause pain. An easy way to solve this issue is to bind it to a collar or anything going above it.",
                    Desc03 = " - Nipples can be very sensitive, and can hurt a lot even after the use of a breast binder. Take care of the spickyness and the pressure of your breast binder.\n - Once again, blood flow is important, if you lose too much sensation after a while wearing a breast binder, you might consider relaxing it a bit.",
                    Category01 = 1,
                    Category02 = 3,
                    Image01 = "BreastBinder01.png",
                    Level = 1
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