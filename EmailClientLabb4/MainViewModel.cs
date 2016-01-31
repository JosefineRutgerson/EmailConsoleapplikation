using EmailClientLabb4.HelperClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EmailClientLabb4
{
    class MainViewModel : ObservableObject
    {
        //private ObservableCollection<Mail> myMailList;
        //private ObservableCollection<Settings> mySettings;
        public ObservableCollection<Contacts> collectionOfContacts = new ObservableCollection<Contacts>();
        public Messages MyMessageService = new Messages();
        private Mail _newMail;
        //private Settings _mySettings;
        // --- Delegates ----
        delegate void IsSeenDelegate();
        //private IsSeenDelegate _isSeen;
        delegate void DeleteTheContactDelegate(Contacts deleteContact);
        private DeleteTheContactDelegate _deleteTheContact;
        delegate Mail createMailDelegate();
        private createMailDelegate createMessage;
        delegate void DeleteMailDelegate(Mail selectedMail);
        private DeleteMailDelegate _deleteMail;
        delegate void SaveSettingsDelegate();
        private SaveSettingsDelegate saveSettingsByDelegate;
        // --- mail object ----
        public Mail NewMail
        {
            get
            { if (_newMail == null)
                    _newMail = new Mail();
                return _newMail;
            }
            set
            {
                _newMail = value;
                OnPropertyChanged("NewMail");
            }
        }

        public Settings MySettings
        {
            get { return Settings.theSetting; }
            set
            {
                Settings.theSetting = value;
                OnPropertyChanged("MySettings");
            }
                  
        }

        

        public MainViewModel()
        {
            Settings.theSetting = new Settings();
            Settings.theSetting.readTheFile();
            MyMessageService.readTheFile();
            //MyMessages = new ObservableCollection<Mail>(MyMessageService.SavedList.Values.ToList());

            // --delegate subscription ---
            _deleteTheContact += Settings.theSetting.DeleteContact;
            createMessage += BaseMessageHandler.createMail;
            _deleteMail += MyMessageService.RemoveMessage;
            saveSettingsByDelegate += Settings.theSetting.saveTheFile;
            //_isSeen += BaseMessageHandler.MailIsSeen (Mail, theMail);
            //--- The Mail ----
            //_sender = "Josefine";
            //_receiver = "Mendokse";
            //_subject = NewMail.Subject;
            //_messageContent = NewMail.Message;

            foreach (var contact in Settings.theSetting.myReceivers)
            {
                collectionOfContacts.Add(contact);
            }

            _theAddedContact.Name = "";

            _listViewMeny = new ObservableCollection<string>();
            _listViewMeny.Add("Inbox");
            _listViewMeny.Add("New Message");
            _listViewMeny.Add("Settings");

            sendMailButton = "Send";


           

        }

        // -- Property for the button text --
        private string sendMailButton;
        public string ButtonTextSend
        {
            get { return sendMailButton; }
            set
            {
                sendMailButton = value;
                OnPropertyChanged("ButtonTextSend");
            }
        }

       
        // ------ Inbox -----------
        //private ObservableCollection<Mail> _myMessages;
        //private Messages messages;
        public ObservableCollection<Mail> MyMessages
        {
            get { return new ObservableCollection<Mail>(MyMessageService.SavedList.Values); }
            /*
            set
            {
                if (myMailList!= value)
                {
                    myMailList = value;
                    OnPropertyChanged("MyMessages");
                }
            }
            */
            
        }

        // --- select mail in inbox ---
        private Mail theMail;
        public Mail SelectMail
        {
            get { return theMail; }
            set
            {
                if (theMail != value)
                {
                    theMail = value;
                    TheShowMailVisibility = true;
                    //BaseMessageHandler.MailIsSeen(SelectMail);
                    OnPropertyChanged("SelectMail");
                }
            }
        }

        
	

        // --- Contact list property---
        public ObservableCollection<Contacts> MyContacts
        {
            //get { return new ObservableCollection<Contacts>(Settings.theSetting.myReceivers); }
            get { return collectionOfContacts; }
        }

        private Contacts _theChosenContact;
        public Contacts SelectedContact
        {
            get { return _theChosenContact; }
            set
            {
                if (_theChosenContact != value)
                {
                    _theChosenContact = value;
                }
                OnPropertyChanged("SelectedContact");
            }
        }

        private Contacts _theAddedContact = new Contacts();
        public Contacts TheAddedContact
        {
            get { return _theAddedContact; }
            set
            {
                if (_theAddedContact != value)
                {
                    _theAddedContact = value;
                }
                OnPropertyChanged("TheAddedContact");
            }
        }


        // Visibility properties
        private bool visibleInboxView;
        public bool TheInboxVisibility
        {
            get { return visibleInboxView; }
            set
            {
                if (visibleInboxView != value)
                {
                    visibleInboxView = value;
                }
                OnPropertyChanged("TheInboxVisibility");
            }
                     
        }

        private bool visibleNewMessageView;
        public bool TheNewMessageVisibility
        {
            get { return visibleNewMessageView; }
            set
            {
                if (visibleNewMessageView != value)
                {
                    visibleNewMessageView = value;
                }
                OnPropertyChanged("TheNewMessageVisibility");
            }
        }

        private bool visibleSettingsView;
        public bool TheSettingsVisibility
        {
            get { return visibleSettingsView; }
            set
            {
                if (visibleSettingsView != value)
                {
                    visibleSettingsView = value;
                }
                OnPropertyChanged("TheSettingsVisibility");
            }
        }

        private bool visibleShowMailView;
        public bool TheShowMailVisibility
        {
            get { return visibleShowMailView; }
            set
            {
                if (visibleShowMailView != value)
                {
                    visibleShowMailView = value;
                }
                OnPropertyChanged("TheShowMailVisibility");
            }
        }

        

        //-----  -------


       

        private ObservableCollection<string> _listViewMeny;
        public ObservableCollection<string> MyMenyList
        {
            get { return _listViewMeny; }
            set
            {
                _listViewMeny = value;
            }
        }

        // -- View Choice --    
        private string _menyChoice;
        public string MenyChoice
        {
            get { return _menyChoice; }
            set
            {
                if (_menyChoice != value)
                {
                    _menyChoice = value;
                    if (value == "Inbox")
                    {
                        TheInboxVisibility = true;
                        TheNewMessageVisibility = false;
                        TheSettingsVisibility = false;
                        TheShowMailVisibility = false;
                        
                    }
                    else if (value == "New Message")
                    {
                        TheNewMessageVisibility = true;
                        TheInboxVisibility = false;
                        TheSettingsVisibility = false;
                        TheShowMailVisibility = false;
                        
                        NewMail = BaseMessageHandler.createMail();
                    }
                    else if (value == "Settings") 
                    {
                        TheSettingsVisibility = true;
                        TheNewMessageVisibility = false;
                        TheShowMailVisibility = false;
                        TheInboxVisibility = false;
                        
                    }
                    OnPropertyChanged("MenyChoice");
                }

            }
        }

        
        // ---Save Mail button ----

        public ICommand SaveMailToFileCommand => new CommandHandler(SaveMailToFile);
        private void SaveMailToFile()
        {
            MyMessageService.CreateMessage(NewMail);
            OnPropertyChanged("MyMessages");
            NewMail = BaseMessageHandler.createMail();

        }

        // --- Delete Mail button ---
        public ICommand DeleteMailFromFileCommand => new CommandHandler(DeleteMailFromFile);
        private void DeleteMailFromFile()
        {
            _deleteMail(SelectMail);
            OnPropertyChanged("SelectMail");
            OnPropertyChanged("MyMessages");
            OnPropertyChanged("myMailList");
            TheShowMailVisibility = false;
        }

        // --- Save settings button ---
        public ICommand SaveSettingsCommand => new CommandHandler(SaveSettings);
        private void SaveSettings()
        {
            Settings.theSetting.AddToContacts(TheAddedContact);
            collectionOfContacts.Add(TheAddedContact);
            saveSettingsByDelegate();
            
            OnPropertyChanged("TheAddedContact");
            //OnPropertyChanged("MyContacts");
            //OnPropertyChanged()
            //MySettings.saveTheFile();
            //Settings.theSetting.saveTheFile();
            
        }

        // --- Delete contact button ---
        public ICommand DeleteTheContactCommand => new CommandHandler(DeleteTheContact);
        private void DeleteTheContact()
        {
            _deleteTheContact(SelectedContact);
            collectionOfContacts.Remove(SelectedContact);
            OnPropertyChanged("MyContacts");
        }



        //public ICommand ChangeTextCommand => new CommandHandler(ChangeText);
        //private void ChangeText()
        //{
        //    TheText = "Doshte..";
        //}



        //public ICommand ChangeTextCommand
        //{
        //    get { return new CommandHandler(ChangeText); }
        //}

        //private string _name;
        //public string Name
        //{
        //    get { return _name; }
        //    set
        //    {
        //        _name = value;
        //        OnPropertyChanged("Name");
        //    }
        //}

    }
}
