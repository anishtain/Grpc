using Grpc.Core;
using GrpcServer;

namespace GrpcServer.Services
{
    public class NoteService : Note.NoteBase
    {
        public override async Task<GetNoteResponse> GetNote(GetNoteRequest request, ServerCallContext context)
        {
            switch (request.Id)
            {
                case 1:
                    return new GetNoteResponse()
                    {
                        Id = 1,
                        Title = "hi",
                        Text = "i'm first note",
                        CreateDate = DateTime.Now.ToString()
                    };
                case 2:
                    return new GetNoteResponse()
                    {
                        Id = 2,
                        Title = "by",
                        Text = "i'm second note",
                        CreateDate = DateTime.Now.ToString()
                    };
                case 3:
                    return new GetNoteResponse()
                    {
                        Id = 3,
                        Title = "by",
                        Text = "i'm thired note",
                        CreateDate = DateTime.Now.ToString()
                    };
                default:
                    return null;
            }
        }

        public override async Task GetNoteList(GetNoteListRequest request, IServerStreamWriter<GetNoteListResponse> responseStream, ServerCallContext context)
        {
            var noteList = new List<GetNoteListResponse>()
            {
                new GetNoteListResponse()
                    {
                        Id = 1,
                        Title = "hi",
                        Text = "i'm first note",
                        CreateDate = DateTime.Now.ToString()
                    },
                new GetNoteListResponse()
                    {
                        Id = 2,
                        Title = "by",
                        Text = "i'm second note",
                        CreateDate = DateTime.Now.ToString()
                    },
                new GetNoteListResponse()
                    {
                        Id = 3,
                        Title = "by",
                        Text = "i'm thired note",
                        CreateDate = DateTime.Now.ToString()
                    }

            };

            foreach(var item in noteList)
            {
                await responseStream.WriteAsync(item);
            }
        }
    }
}
