"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Job = void 0;
var Job = /** @class */ (function () {
    function Job() {
        this.jobs = [
            {
                title: 'Juniour Process Associate',
                companyName: 'Aitrich Technologies',
                description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and desinging fully-functional products',
                location: 'Indonesia',
                employmentType: 'Full Time',
                experienceLevel: 'Mid Level',
                salaryRange: '$3000 - $5000'
            },
            {
                title: 'Customer Service Executive',
                companyName: 'ciinfosys',
                description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and desinging fully-functional products',
                location: 'Indonesia',
                employmentType: 'Full Time',
                experienceLevel: 'Mid Level',
                salaryRange: '$3000 - $5000'
            },
            {
                title: 'Customer Service Executive',
                companyName: 'Infotech',
                description: 'Product designer responsibilities include defining product specifications, creating digital or print drawing and desinging fully-functional products',
                location: 'Indonesia',
                employmentType: 'Full Time',
                experienceLevel: 'Mid Level',
                salaryRange: '$3000 - $5000'
            }
        ];
    }
    Job.prototype.getAllJobs = function () {
        this.jobs.map(function (job) {
            console.log("");
            console.log("Job Title : ".concat(job.title));
            console.log("Job Title : ".concat(job.companyName));
            console.log("Description : ".concat(job.description));
            console.log("Salary Range : ".concat(job.salaryRange));
            console.log("Experience Level: ".concat(job.experienceLevel));
            console.log("");
            console.log("------------------------------------------------------------------------------------------------------------");
        });
    };
    return Job;
}());
exports.Job = Job;
