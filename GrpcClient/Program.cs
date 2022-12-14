using Grpc.Net.Client;
using GrpcServer;

Console.WriteLine("Hello");
var channel = GrpcChannel.ForAddress("https://localhost:7123/");
var client = new Note.NoteClient(channel);

var note = client.GetNote(new GetNoteRequest() { Id = 1 });
Console.WriteLine($"{note.Title}  |   {note.Text}");

var noteList = client.GetNoteList(new GetNoteListRequest());

using (var call = client.GetNoteList(new GetNoteListRequest()))
{
    while (await call.ResponseStream.MoveNext(new CancellationToken()))
    {
        var n = call.ResponseStream.Current;
        Console.WriteLine($"{n.Title}  |   {n.Text}");
    }
}