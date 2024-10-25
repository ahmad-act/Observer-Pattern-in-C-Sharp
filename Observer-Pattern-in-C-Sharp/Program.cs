using Observer_Pattern_in_C_Sharp;

// Display introductory information about the news publisher and readers
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("There is one News Publisher and three readers - Alice, Bob, and Charlie. Only two readers, Alice and Bob, are subscribed.");
Console.ResetColor();

// Create a news publisher
var publisher = new NewsPublisher();

// Create reader instances (subscribers)
var user1 = new Reader("Alice"); // Alice will subscribe to news updates
var user2 = new Reader("Bob");   // Bob will also subscribe to news updates
var user3 = new Reader("Charlie"); // Charlie will not subscribe

// Users subscribe to the news publisher
user1.Subscribe(publisher); // Alice subscribes
user2.Subscribe(publisher); // Bob subscribes

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"\n{user1.UserName} and {user2.UserName} have subscribed for news updates.");
Console.ResetColor();

// Publish news articles
// Alice and Bob will receive the news, but Charlie will not
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\nPublishing news articles..."); 
Console.ResetColor();
publisher.PublishNews("Breaking: Major earthquake hits city!"); 

// Bob unsubscribes from the news publisher
user2.Unsubscribe(); // Bob will no longer receive updates

// Notify about unsubscription
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"\n{user2.UserName} has unsubscribed from news updates."); 
Console.ResetColor();

// Publish more news after Bob has unsubscribed
// Now, only Alice will receive the news, while Bob (unsubscribed) and Charlie (not subscribed) will not
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\nPublishing more news articles after Bob has unsubscribed...");
Console.ResetColor();
publisher.PublishNews("Sports: Local team wins championship!");
