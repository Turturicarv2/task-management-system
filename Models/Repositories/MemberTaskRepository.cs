using task_management_system.Data;
using task_management_system.Models.DBModels;

public class MemberTaskRepository
{
    private ApplicationDbContext dbContext;

    public MemberTaskRepository()
    {
        this.dbContext = new ApplicationDbContext();
    }

    public MemberTaskRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public List<MemberTaskModel> GetAllMemberTasksByUserId(string userId)
    {
        List<MemberTaskModel> memberTaskModels = new List<MemberTaskModel>();

        foreach (MemberTask task in dbContext.Tasks)
        {
            if (task.AssignedUserId == userId)
            {
                memberTaskModels.Add(MapDbObjectToModel(task));
            }
        }

        return memberTaskModels;
    }

    public MemberTaskModel GetMemberTaskById(int Id)
    {
        return MapDbObjectToModel(dbContext.Tasks.FirstOrDefault(x => x.Id == Id));
    }

    public void InsertMemberTask(MemberTaskModel model)
    {
        var dbObject = MapModelToDbObject(model);

        dbObject.AssignedUser = dbContext.Users.FirstOrDefault(u => u.Id == model.AssignedUserId);

        dbContext.Add(dbObject);
        dbContext.SaveChanges();
    }

    public void UpdateMemberTask(MemberTaskModel model)
    {
        MemberTask task = dbContext.Tasks.FirstOrDefault(x => x.Id == model.Id);

        if (task != null)
        {
            task.Title = model.Title;
            task.Description = model.Description;
            task.Status = model.Status;
            task.AssignedUser = model.AssignedUser;
            task.AssignedUserId = model.AssignedUserId;
            task.DueDate = model.DueDate;
        }
    }

    public void DeleteMemberTask(MemberTaskModel model)
    {
        MemberTask task = dbContext.Tasks.FirstOrDefault(x => x.Id == model.Id);

        if (task != null)
        {
            dbContext.Tasks.Remove(task);
            dbContext.SaveChanges();
        }
    }

    private MemberTaskModel MapDbObjectToModel(MemberTask task)
    {
        MemberTaskModel model = new MemberTaskModel();

        if (task != null )
        {
            model.Id = task.Id;
            model.Title = task.Title;
            model.Description = task.Description;
            model.AssignedUserId = task.AssignedUserId;
            model.Status = task.Status;
            model.DueDate = task.DueDate;
            model.AssignedUser = task.AssignedUser;
        }

        return model;
    }

    private MemberTask MapModelToDbObject(MemberTaskModel model)
    {
        MemberTask task = new MemberTask();

        if (model != null)
        {
            task.Id = model.Id;
            task.Title = model.Title;
            task.Description = model.Description;
            task.AssignedUserId = model.AssignedUserId;
            task.Status = model.Status;
            task.DueDate = model.DueDate;
            task.AssignedUser = model.AssignedUser;
        }

        return task;
    }
}

