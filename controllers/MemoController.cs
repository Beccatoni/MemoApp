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
}