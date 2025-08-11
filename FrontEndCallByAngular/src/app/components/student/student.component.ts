import { Component, ElementRef, inject, ViewChild } from '@angular/core';
import { Student } from '../../Model/student';
import { StudentService } from '../../service/student.service';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-student',
  imports: [ReactiveFormsModule],
  templateUrl: './student.component.html',
  styleUrl: './student.component.css'
})
export class StudentComponent {

  @ViewChild('myModal') model: ElementRef | undefined;
  studentList: Student[] = [];
  stuService = inject(StudentService);
  studentForm : FormGroup= new FormGroup({});
  
   constructor(private fb: FormBuilder) { }
   ngOnInit(): void {
     this.setFormState();
     this.getStudents();
     }
  openModel() {
    const empModel = document.getElementById('myModal');
    if (empModel != null) {
      empModel.style.display = 'block';
    }
  }

  closeModal() {
    this.setFormState();
    if (this.model != null) {
      this.model.nativeElement.style.display = 'none';
    }
  }
 
  getStudents() {
    this.stuService.getAllStudent().subscribe((res: any) => {
      this.studentList = res;
    });
  }
  
  setFormState()
  {
    this.studentForm = this.fb.group({
      id: [0],
      stname: ['', Validators.required],
      course: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      age: ['', Validators.required]
   });
  }
  formValue : any
  onSubmit() {
    console.log(this.studentForm.value);
    if (this.studentForm.invalid) {
      alert('Please Fill All Fields');
      return;
    }
    if (this.studentForm.value.id == 0) {
      this.formValue = this.studentForm.value;
      this.stuService.addStudent(this.formValue).subscribe((res:any) => {

        alert('Employee Added Successfully');
        this.getStudents();
        this.studentForm.reset();
        this.closeModal();

      });
    } else {
      this.formValue = this.studentForm.value;
      this.stuService.updateStudent(this.formValue).subscribe((res: any) => {

        alert('Employee Updated Successfully');
        this.getStudents();
        this.studentForm.reset();
        this.closeModal();

      });
    }

  }
  
  onEdit(student : Student)
  {
    this.openModel();
    this.studentForm.patchValue(student);
  }
  onDelete(student : Student){
    const isConfirm = confirm("Are you sure you want to delete this Employee " + student.stname);
    if (isConfirm) {
    this.stuService.deleteStudent(student.id).subscribe((res : any)=>{
      alert("Student deleted successfully...");
      this.getStudents();
    });
   }
  }
}  

