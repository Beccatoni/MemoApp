using MemoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoApp.Repository;

public interface IMemoRepository
{
  IEnumerable<Memo> GetAllMemos();
  // Memo? GetMemoById(int id);
  void AddMemo(Memo memo);
  // void UpdateMemo(Memo memo, int id);
  // void CreateMemo(Memo memo);
  // void DeleteMemo(int id);
  // void SaveChages();
}
public class MemoRepository : IMemoRepository
{
  private readonly AppDbContext _context;

  public MemoRepository(AppDbContext context)
  {
    _context = context;
  }
  public IEnumerable<Memo> GetAllMemos() => _context.Memos.ToList();

  public void AddMemo(Memo memo)
  {
    _context.Memos.Add(memo);
    _context.SaveChanges();
  }

}