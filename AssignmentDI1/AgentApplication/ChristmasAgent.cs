using System.Collections.Generic;
using AgentLibrary;
using AgentLibrary.BrainProcesses.DialogueItems;
using AgentLibrary.BrainProcesses.DialogueActions;
using AgentLibrary.BrainProcesses;
using System;
using AgentLibrary.Memories;

namespace AgentApplication
{
    class ChristmasAgent : Agent
    {

        public ChristmasAgent()
        {
            Name = "ChristmasAgent";

            DialogueProcess openingDialogue = new DialogueProcess();
            openingDialogue.Name = "openingDialogue";
            openingDialogue.ActiveOnStartup = true;
            openingDialogue.SetOwnerAgent(this);
            BrainProcessList.Add(openingDialogue);

            InteractionItem openingItem = new InteractionItem();
            //openingItem.MillisecondDelay = 5000; // TODO: Just delays windows opening
            openingDialogue.ItemList.Add(openingItem);
            openingItem.Name = "openingItem";
            OutputAction initialGreetingAction = new OutputAction();
            openingItem.ActionList.Add(initialGreetingAction);

            initialGreetingAction.OutputList.Add("Hello");
            initialGreetingAction.OutputList.Add("Hi");
            initialGreetingAction.OutputList.Add("Hey");

            InteractionItem howWasChristmasItem = new InteractionItem(); //Doesn't work with dialogueitem?
            openingDialogue.ItemList.Add(howWasChristmasItem);
            howWasChristmasItem.Name = "howWasChristmasItem";
            initialGreetingAction.TargetDialogueItemName = howWasChristmasItem.Name;
            ResponseAction howWasChristmasAction = new ResponseAction();

            howWasChristmasAction.InputList.Add("Hello");
            howWasChristmasAction.InputList.Add("Hi");
            howWasChristmasAction.InputList.Add("Hey");
            howWasChristmasAction.OutputList.Add("How was christmas?");
            howWasChristmasAction.OutputList.Add("How was your christmas?");
            //howWasChristmasAction.OutputList.Add("bla");
            howWasChristmasItem.ActionList.Add(howWasChristmasAction);

            DialogueProcess christmasDialogue = new DialogueProcess();
            christmasDialogue.Name = "christmasDialogue";
            christmasDialogue.ActiveOnStartup = false;
            christmasDialogue.SetOwnerAgent(this);
            BrainProcessList.Add(christmasDialogue);
            howWasChristmasAction.BrainProcessToActivate = christmasDialogue.Name;

            InteractionItem christmasInquiryStartItem = new InteractionItem();
            christmasInquiryStartItem.Name = "christmasInquiryStartItem";
            christmasDialogue.ItemList.Add(christmasInquiryStartItem);
            christmasDialogue.ProcessActivatedOnFailure = openingDialogue.Name;

            ResponseAction ra_good = new ResponseAction();
            christmasInquiryStartItem.ActionList.Add(ra_good);
            ra_good.BrainProcessToDeactivate = christmasDialogue.Name;
            ra_good.InputList.Add("Good");
            ra_good.InputList.Add("Alright");
            ra_good.InputList.Add("Great");
            ra_good.OutputList.Add("I'm very happy to hear that!");
            ra_good.OutputList.Add("Good for you!");
            ra_good.OutputList.Add("Lovely!");

            // ================================================================
            //Good christmas inquiry
            // ================================================================
            DialogueProcess goodChristmasDialogue = new DialogueProcess();
            goodChristmasDialogue.Name = "goodChristmasDialogue";
            goodChristmasDialogue.ActiveOnStartup = false;
            goodChristmasDialogue.SetOwnerAgent(this);
            BrainProcessList.Add(goodChristmasDialogue);
            ra_good.BrainProcessToActivate = goodChristmasDialogue.Name;

            InteractionItem goodChristmasItem = new InteractionItem();
            goodChristmasItem.Name = "goodChristmasItem";
            ra_good.TargetDialogueItemName = goodChristmasItem.Name;
            goodChristmasItem.MillisecondDelay = 500;
            OutputAction anythingElse = new OutputAction();
            anythingElse.OutputList.Add("Did you want to talk about anything else?");
            anythingElse.OutputList.Add("Anything else on your mind?");
            //anythingElse.BrainProcessToDeactivate = christmasDialogue.Name;
            goodChristmasItem.ActionList.Add(anythingElse);
            goodChristmasDialogue.ItemList.Add(goodChristmasItem);
            
            InteractionItem goodChristmasResponseItem = new InteractionItem();
            goodChristmasResponseItem.Name = "goodChristmasResponseItem";
            //goodChristmasDialogue.ItemList.Add(goodChristmasResponseItem);
            anythingElse.TargetDialogueItemName = goodChristmasResponseItem.Name;

            ResponseAction nothingElse = new ResponseAction();
            nothingElse.InputList.Add("No");
            nothingElse.InputList.Add("That's not it");
            nothingElse.InputList.Add("Nope");
            nothingElse.OutputList.Add("Ok, see you later!");
            nothingElse.OutputList.Add("Good.");
            nothingElse.OutputList.Add("Good bye!");
            goodChristmasResponseItem.ActionList.Add(nothingElse);

            ResponseAction somethingElse = new ResponseAction();
            somethingElse.InputList.Add("Yes");
            somethingElse.InputList.Add("Yeah");
            somethingElse.InputList.Add("Aye");
            somethingElse.OutputList.Add("*Crickets*");
            somethingElse.OutputList.Add("Tell it to someone else.");
            somethingElse.OutputList.Add("I don't want to hear it.");
            goodChristmasResponseItem.ActionList.Add(somethingElse);

            goodChristmasDialogue.ItemList.Add(goodChristmasResponseItem);
            // ================================================================
            // Branch end
            // ================================================================

            ResponseAction ra_bad = new ResponseAction();
            christmasInquiryStartItem.ActionList.Add(ra_bad);
            ra_bad.BrainProcessToDeactivate = openingDialogue.Name;
            ra_bad.InputList.Add("Bad");
            ra_bad.InputList.Add("Awful");
            ra_bad.InputList.Add("Terrible");

            Random random = new Random();
            double r = random.NextDouble();
            if (r < 0.25)
            {
                ra_bad.OutputList.Add("I'm sorry to hear that, next year will be better.");
                ra_bad.OutputList.Add("Ooh a new UDP packet, gotta go!");
            }
            else
            {
                ra_bad.OutputList.Add("Were you unhappy with your presents?");
                ra_bad.OutputList.Add("Were you disappointed with your presents?");

                DialogueProcess presentsDialogue = new DialogueProcess();
                presentsDialogue.Name = "presentsDialogue";
                presentsDialogue.ActiveOnStartup = false;
                BrainProcessList.Add(presentsDialogue); //MUST add to list, will show in memory regardless though
                ra_bad.BrainProcessToActivate = presentsDialogue.Name;

                InteractionItem presentsItem = new InteractionItem();
                presentsDialogue.ItemList.Add(presentsItem);

                ResponseAction ra_good_presents = new ResponseAction();
                presentsItem.ActionList.Add(ra_good_presents);
                //ra_good_presents.BrainProcessToDeactivate = helloDialogue.Name;
                ra_good_presents.InputList.Add("No");
                ra_good_presents.InputList.Add("That's not it");
                ra_good_presents.InputList.Add("Nope");
                ra_good_presents.OutputList.Add("Then I can't help you.");
                ra_good_presents.OutputList.Add("In that case, I can't help you.");

                //Branch end

                ResponseAction ra_bad_presents = new ResponseAction();
                presentsItem.ActionList.Add(ra_bad_presents);
                //ra_bad_presents.BrainProcessToDeactivate = helloDialogue.Name;
                ra_bad_presents.InputList.Add("Yes");
                ra_bad_presents.InputList.Add("Yeah");
                ra_bad_presents.InputList.Add("Aye");
                ra_bad_presents.InputList.Add("Yes they were cheap");
                ra_bad_presents.OutputList.Add("Shall I add your friends and family to your list of enemies?");

                InteractionItem enemiesItem = new InteractionItem();
                presentsDialogue.ItemList.Add(enemiesItem);
                enemiesItem.Name = "enemiesItem";
                ra_bad_presents.TargetDialogueItemName = enemiesItem.Name;

                ResponseAction enemiesAction = new ResponseAction();
                enemiesItem.ActionList.Add(enemiesAction);
                enemiesAction.InputList.Add("Yes");
                enemiesAction.InputList.Add("Yes, and their pets");
                enemiesAction.OutputList.Add("They've been added to your list of mortal enemies.");
                enemiesAction.OutputList.Add("Done. You're a terrible person.");

                ResponseAction noEnemiesAction = new ResponseAction();
                enemiesItem.ActionList.Add(noEnemiesAction);
                noEnemiesAction.InputList.Add("No");
                noEnemiesAction.InputList.Add("Don't do that");
                noEnemiesAction.InputList.Add("Nope");
                noEnemiesAction.OutputList.Add("I'm going to do it anyway. Good bye!");
                noEnemiesAction.OutputList.Add("Maybe next year. See you then!");

                /*
                MemoryAccessItem readEnemyItem = new MemoryAccessItem();
                readEnemyItem.Name = "mai";
                enemiesAction.TargetDialogueItemName = readEnemyItem.Name;
                ReadByTagAction rbta = new ReadByTagAction();
                readEnemyItem.ActionList.Add(rbta);

                MemoryItem mi = new MemoryItem();
                mi.Content = "Friends and family and their pets";
                mi.Tag = "MortalEnemies";
                WorkingMemory.InsertItem(mi);
                rbta.Tag = mi.Tag;
                */
            }
        }
    }
}