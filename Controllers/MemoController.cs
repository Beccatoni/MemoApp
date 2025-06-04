using MemoApp.DTOs;
using MemoApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemoApp.Controllers;

[ApiController]
[Route("[controller]")]
public class MemoController: ControllerBase
{
    private readonly IMemoService _memoService;

    public MemoController(IMemoService memoService)
    {
        _memoService = memoService;
    }

    [HttpGet]
    public IEnumerable<MemoDto> GetMemos()
    {
        return _memoService.GetAllMemos();
    }

    [HttpPost]
    public IActionResult CreateMemo([FromBody] CreateMemoDto newMemo)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _memoService.AddMemo(newMemo);
        return CreatedAtAction(nameof(GetMemos), null);
    }

    [HttpPatch("{id:int}")]
    public IActionResult UpdateMemo(int id, [FromBody] UpdateMemoDto memo)
    {
        if (string.IsNullOrWhiteSpace(memo.Title) && string.IsNullOrWhiteSpace(memo.Content))
        {
            return BadRequest("At least one field must be updated.");
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _memoService.UpdateMemo(memo, id);
        return NoContent();
      
    }
}