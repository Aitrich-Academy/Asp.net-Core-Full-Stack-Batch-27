interface Jobseeker {
  title: string;
  companyName: string;
  description: string;
  salaryRange: string;
  location: string;
  experienceLevel: string;
  employmentType: string;
}

export class JobseekerManager {
  private seekers: Jobseeker[] = [
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

  getAllJobseekers() {
    this.seekers.forEach((job) => {
      console.log(`employmentType: ${job.employmentType}`);
      console.log(`Job Title: ${job.title}`);
      console.log(`Company Name: ${job.companyName}`);
      console.log(`Description: ${job.description}`);
      console.log(`Salary Range: ${job.salaryRange}`);
      console.log(`Experience Level: ${job.experienceLevel}`);
      console.log(`location: ${job.location}`);
      console.log("------------------------------------------------------------------------------------------------------------");
    });
  }

  removeJobseekerByCompany(companyName: string) {
    const initialCount = this.seekers.length;
    this.seekers = this.seekers.filter((job) => job.companyName !== companyName);
    const finalCount = this.seekers.length;
    const removedCount = initialCount - finalCount;
    console.log(`Removed ${removedCount} job seeker(s) with the company name "${companyName}".`);
  }
}
