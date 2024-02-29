namespace Mission8_Grp1_6.Models
{
    public class EFCategoryRepository
    {
        private TaskContext _context;
        public EFCategoryRepository(TaskContext temp)
        {
            _context = temp;
        }

        public List<Category> Categories => _context.Categories.ToList();
    }
}
