todo-sync
=========
TODO ITEMS

CORE
* SQLite Database
* [PrimaryKey, AutoIncrement] on Model ID
* Service Resolver - (See Jonathan Peppers book or James Montemagno projects)
* Web Service
* Todo Service
* TodoViewModel / ViewModelBase

    public class ToDoItem
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
    }

ANDROID
* TodoActivity
* TodosAdapter
* TodosActivity

IOS
* TodoViewController
* TodosTableViewController
* TodosTableViewSource

WINPHONE
* TodoPage
* TodosPage
