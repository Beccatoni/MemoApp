using MemoApp.DTOs;
using MemoApp.Models;
using MemoApp.Repository;

namespace MemoApp.Services;

public interface IMemoService
{
    IEnumerable<MemoDto> GetAllMemos();
    // MemoDto? GetMemoById(int id);
    void AddMemo(CreateMemoDto memo);
    // void UpdateMemo(MemoDto memo, int id);
    // void CreateMemo(MemoDto memo);
    // void DeleteMemo(int id);
    // void SaveChages();
}
public class MemoService : IMemoService
{
    private readonly IMemoRepository _repository;
    
    public MemoService(IMemoRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<MemoDto> GetAllMemos()
    {
        var memos = _repository.GetAllMemos();
        return memos.Select(memo => new MemoDto
        {
            Id = memo.Id,
            Title = memo.Title,
            Content = memo.Content,
            CreatedAt = memo.CreatedAt,
            UpdatedAt = memo.UpdatedAt
        }).ToList();
    }

    public void AddMemo(CreateMemoDto newMemo)
    {
        var memo = new Memo
        {
            Title = newMemo.Title,
            Content = newMemo.Content,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        _repository.AddMemo(memo);
    }
}