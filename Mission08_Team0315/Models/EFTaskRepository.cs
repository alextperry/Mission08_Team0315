

namespace Mission08_Team0315.Models
{
    public class EFTaskRepository : ITaskRepository
    {

        private QuadrantContext _quadrantContext;

        public EFTaskRepository(QuadrantContext temp) 
        {
            _quadrantContext = temp;
        }
        public List<ToDoListForm> Tasks => _quadrantContext.Tasks.ToList();

    }
}

