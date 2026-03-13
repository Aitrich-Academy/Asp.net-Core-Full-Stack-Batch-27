"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.JobseekerManager = void 0;
var JobseekerManager = /** @class */ (function () {
    function JobseekerManager() {
        this.seekers = [
            {
                title: 'Juniour Process Associate',
                companyName: 'Aitrich Technologies',
                description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and designing fully-functional products',
                location: 'Indonesia',
                employmentType: 'Full Time',
                experienceLevel: 'Mid Level',
                salaryRange: '$3000 - $5000'
            },
            {
                title: 'Customer Service Executive',
                companyName: 'Ciinfopsys',
                description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and designing fully-functional products',
                location: 'Indonesia',
                employmentType: 'Full Time',
                experienceLevel: 'Mid Level',
                salaryRange: '$3000 - $5000'
            },
            {
                title: 'Customer Service Executive',
                companyName: 'Pix Dynamics',
                description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and designing fully-functional products',
                location: 'Indonesia',
                employmentType: 'Full Time',
                experienceLevel: 'Mid Level',
                salaryRange: '$3000 - $5000'
            }
        ];
    }
    JobseekerManager.prototype.getAllJobseekers = function () {
        this.seekers.forEach(function (job) {
            console.log("employmentType: ".concat(job.employmentType));
            console.log("Job Title: ".concat(job.title));
            console.log("Company Name: ".concat(job.companyName));
            console.log("Description: ".concat(job.description));
            console.log("Salary Range: ".concat(job.salaryRange));
            console.log("Experience Level: ".concat(job.experienceLevel));
            console.log("location: ".concat(job.location));
            console.log("------------------------------------------------------------------------------------------------------------");
        });
    };
    JobseekerManager.prototype.removeJobseekerByCompany = function (companyName) {
        var initialCount = this.seekers.length;
        this.seekers = this.seekers.filter(function (job) { return job.companyName !== companyName; });
        var finalCount = this.seekers.length;
        var removedCount = initialCount - finalCount;
        console.log("Removed ".concat(removedCount, " job seeker(s) with the company name \"").concat(companyName, "\"."));
    };
    return JobseekerManager;
}());
exports.JobseekerManager = JobseekerManager;
