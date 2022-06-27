using StreamingContent_Repository;
using SC_DI_Console.UI;

public class ProgramUI
{
    public readonly StreamingContentRepository _repo = new StreamingContentRepository();
    private readonly IConsole _console;

    public ProgramUI(IConsole console){
        _console = console;
    }

    public void Run() {
        // put some basic content into my "_repo" collection
        Seed();

        // handles menu options/logic for the user
        RunMenu();
    }

    public void RunMenu() {
        // want this to continue running until user has specified "Exit"
        // 1: boolean variable to trigger our do/while "menu" code execution
        bool continueToRun = true;
        // 2: do/while loop with functionality for UI
        do
        {
            _console.Clear();
            _console.WriteLine("Welcome to our Streaming Content Interface! Please select from one of our menu options:\n" + 
            "1. Create new streaming content\n" + 
            "2. List all streaming content\n" + 
            "3. Get content by title\n" + 
            "4. Update existing content item\n" + 
            "5. Delete existing content item\n" + 
            "6. Exit");

            string selection = _console.ReadLine();

            switch (selection)
            {
                case "1":
                    CreateStreamingContent();
                    break;
                case "2":
                    ListAllStreamingContent();
                    break;
                case "3":
                    GetContentByTitle();
                    break;
                case "4":
                    UpdateExistingContent();
                    break;
                case "5":
                    DeleteExistingContent();
                    break;
                case "6":
                    _console.Clear();
                    _console.WriteLine("Bye bye!");
                    continueToRun = false;
                    break;
                default:
                    _console.WriteLine("Please enter a valid selection");
                    WaitForKey();
                    break;
            } 
        } while (continueToRun);
    }

    // CREATE
    public void CreateStreamingContent()
    {
        _console.Clear();

        _console.WriteLine("Please enter a title for your new content:");
        string title = _console.ReadLine();

        _console.WriteLine("Please enter a description for your new content:");
        string description = _console.ReadLine();

        // StarRating is DOUBLE in StreamingContent POCO
        _console.WriteLine("Please enter a valid star NUMBER rating between 0-5:");
        double starRating = Convert.ToDouble(_console.ReadLine());

        _console.WriteLine("Please select a NUMBER for the maturity rating from the following options:\n" + 
            "1. G\n" + 
            "2. PG\n" + 
            "3. PG13\n" + 
            "4. R");
        string ratingSelection = _console.ReadLine();

        // SWITCH EXPRESSION!!!
        // variable used when creating new "StreamingContent" instance
        MaturityRating rating = ratingSelection switch {
            "1" => MaturityRating.G,
            "2" => MaturityRating.PG,
            "3" => MaturityRating.PG13,
            "4" => MaturityRating.R,
            _ => MaturityRating.NotRated
        };

        _console.WriteLine("Please select a NUMBER for the type of genre from the following options:\n" + 
            "1. Action\n" + 
            "2. SciFi\n" + 
            "3. Documentary\n" + 
            "4. Western\n" + 
            "5. Drama\n" + 
            "6. RomCom\n" + 
            "7. Horror");
        string genreSelection = _console.ReadLine();

        // SWITCH EXPRESSION!!!
        // variable used when creating new "StreamingContent" instance
        GenreType genre = genreSelection switch {
            "1" => GenreType.Action,
            "2" => GenreType.SciFi,
            "3" => GenreType.Documentary,
            "4" => GenreType.Western,
            "5" => GenreType.Drama,
            "6" => GenreType.RomCom,
            "7" => GenreType.Horror,
            _ => GenreType.Unknown
        };

        StreamingContent newContent = new StreamingContent(title, description, starRating, rating, genre);

        _repo.AddContentToDirectory(newContent);
        _console.Clear();
        _console.WriteLine($"{newContent.Title} has been added to the directory!");
        _console.WriteLine(newContent.IsFamilyFriendly ? "This content is family friendly!" : "Put the kids to sleep before you put this on...");
        
        // * "WaitForKey()" used to stop the "do/while" loop from clearing out code that was just displayed
        WaitForKey();
    }

    // READ ALL
    public void ListAllStreamingContent()
    {
        _console.Clear();
        List<StreamingContent> allContent = _repo.GetAllContent();

        _console.Write("---------------- All Streaming Content ----------------\n");

        if(allContent.Count < 0) {
            _console.WriteLine("There is currently no content to be viewed in this directory. Try option 1 in menu.");
        } else {
            foreach (StreamingContent content in allContent)
            {
                _console.WriteLine($"Title: {content.Title}\n" + 
                    $"Description: {content.Description}\n" + 
                    $"Genre: {content.TypeOfGenre}\n" + 
                    $"Stars: {content.StarRating}\n" + 
                    $"This content is {content.Rating} rated. {(content.IsFamilyFriendly ? "This content is family friendly!" : "Put the kids to sleep before you put this on...")}\n");
            }
        }

        // * "WaitForKey()" used to stop the "do/while" loop from clearing out code that was just displayed
        WaitForKey();
    }
    
    // READ ONE
    public void GetContentByTitle()
    {
        _console.Clear();

        _console.WriteLine("Please enter a title for the content you would like to view: ");
        string title = _console.ReadLine();

        StreamingContent item = _repo.GetContentByTitle(title);

        // * "default" keyword used to compare variable to "default" value of the variable's type
        if (item == default)
        {
            _console.WriteLine("Item not found. Try adding it if you've spelled everything correctly!");
        }
        else
        {
            _console.WriteLine($"Title: {item.Title}\n" + 
                $"Description: {item.Description}\n" + 
                $"Genre: {item.TypeOfGenre}\n" + 
                $"Stars: {item.StarRating}\n" + 
                $"This content is {item.Rating} rated. {(item.IsFamilyFriendly ? "This content is family friendly!" : "Put the kids to sleep before you put this on...")}\n");
        }

        WaitForKey();
    }

    // UPDATE
    public void UpdateExistingContent()
    {
        _console.Clear();

        // * PROMPTING USER TO ENTER A TITLE FOR CONTENT THEY WOULD LIKE TO UPDATE
        _console.WriteLine("Please enter a title for the content you would like to update: ");
        string title = _console.ReadLine();

        StreamingContent updatedContent = new StreamingContent();

        // * PROMPTING USER TO ENTER NEW INFORMATION FOR UPDATED CONTENT BASED ON "StreamingContent" CLASS
        _console.WriteLine("Please enter a new title for the updated content:");
        updatedContent.Title = _console.ReadLine();

        _console.WriteLine("Please enter a new description for the updated content:");
        updatedContent.Description = _console.ReadLine();

        // StarRating is DOUBLE in StreamingContent POCO
        _console.WriteLine("Please enter a valid star NUMBER rating between 0-5 for the updated content:");
        updatedContent.StarRating = Convert.ToDouble(_console.ReadLine());

        _console.WriteLine("Please select a NUMBER for the updated maturity rating from the following options:\n" + 
            "1. G\n" + 
            "2. PG\n" + 
            "3. PG13\n" + 
            "4. R");
        string ratingSelection = _console.ReadLine();

        // SWITCH EXPRESSION!!!
        // variable used when creating new "StreamingContent" instance
        updatedContent.Rating = ratingSelection switch {
            "1" => MaturityRating.G,
            "2" => MaturityRating.PG,
            "3" => MaturityRating.PG13,
            "4" => MaturityRating.R,
            _ => MaturityRating.NotRated
        };

        _console.WriteLine("Please select a NUMBER for the updated type of genre from the following options:\n" + 
            "1. Action\n" + 
            "2. SciFi\n" + 
            "3. Documentary\n" + 
            "4. Western\n" + 
            "5. Drama\n" + 
            "6. RomCom\n" + 
            "7. Horror");
        string genreSelection = _console.ReadLine();

        // SWITCH EXPRESSION!!!
        // variable used when creating new "StreamingContent" instance
        updatedContent.TypeOfGenre = genreSelection switch {
            "1" => GenreType.Action,
            "2" => GenreType.SciFi,
            "3" => GenreType.Documentary,
            "4" => GenreType.Western,
            "5" => GenreType.Drama,
            "6" => GenreType.RomCom,
            "7" => GenreType.Horror,
            _ => GenreType.Unknown
        };

        if (_repo.UpdateExistingContent(title, updatedContent))
        {
            _console.Clear();
            _console.WriteLine($"{updatedContent.Title} has successfully been updated! B-)");
        }
        else
        {
            _console.Clear();
            _console.WriteLine($"{title} could not be found.");
        }

        WaitForKey();
    }

    // DELETE
    public void DeleteExistingContent()
    {
        _console.Clear();

        _console.WriteLine("Please enter a title for the content you would like to DELETE: ");
        string title = _console.ReadLine();

        if (_repo.DeleteExistingContent(title))
        {
            _console.Clear();
            _console.WriteLine($"{title} has successfully been deleted! :'(");
        }
        else
        {
            _console.Clear();
            _console.WriteLine($"{title} could not be found.");
        }

        WaitForKey();
    }

    // * HELPER METHODS
    private void WaitForKey()
    {
        _console.WriteLine("Press any key to continue...");
        _console.ReadKey();
    }

    // adding some basic content for use
    private void Seed()
    {
        StreamingContent trainingDay = new StreamingContent("Training Day", "Ethan Hawke goes on a journey of self discovery as he deals with the sins of a corrupt officer.", 4.8, MaturityRating.R, GenreType.Action);
        StreamingContent fearAndLoathing = new StreamingContent("Fear and Loathing in Las Vegas", "Johnny Depp gets real weird.", 4.2, MaturityRating.R, GenreType.Thriller);
        StreamingContent southPark = new StreamingContent("South Park", "Funny as hell", 5, MaturityRating.R, GenreType.Unknown);

        _repo.AddContentToDirectory(trainingDay);
        _repo.AddContentToDirectory(fearAndLoathing);
        _repo.AddContentToDirectory(southPark);
    }
}