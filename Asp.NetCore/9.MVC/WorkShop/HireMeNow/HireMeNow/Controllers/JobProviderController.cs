using AutoMapper;
using HireMeNow.Dto;
using HireMeNow.Interface;
using HireMeNow.Models;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow.Controllers
{
    public class JobProviderController : Controller
    {
        IMapper _mapper;
        IJobRepository _jobRepository;
        IJobService _jobService;
        IUserRepository _userRepository;

        public JobProviderController(IMapper mapper, IJobRepository jobRepository, IJobService jobService, IUserRepository userRepository)
        {
            _mapper = mapper;
            _jobRepository = jobRepository;
            _jobService = jobService;
            _userRepository = userRepository;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PostJob()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult PostJob(JobDto jobDto)
        {
            var uid = HttpContext.Session.GetString("UserId");


            User user = _userRepository.getById(new Guid(uid));
            jobDto.CompanyId = (Guid)user.CompanyId;

            var job = _mapper.Map<Job>(jobDto);
            bool result = _jobRepository.Create(job);

            if (result == true)
            {

                TempData["Message"] = "Successfully Posted Job";
                return RedirectToAction("AllJobs");
            }
            else
            {
                return View(jobDto);
            }
        }

        public IActionResult AllJobs()
        {
            var uid = HttpContext.Session.GetString("UserId");

            User user = _userRepository.getById(new Guid(uid));

            Guid cmpid = (Guid)user.CompanyId;
            List<Job> Jobs = _jobService.GetJobPosted(cmpid);

            return View(Jobs);
        }
    }
}
