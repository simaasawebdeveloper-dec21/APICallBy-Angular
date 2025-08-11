import { inject, Injectable } from '@angular/core';
import { Student } from '../Model/student';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
private apiUrl= 'https://localhost:7015/api/Student'
  constructor() { }
  http = inject(HttpClient);

  getAllStudent(){
    return this.http.get<Student[]>(this.apiUrl);
  }
  addStudent(data: Student) {
    return this.http.post<Student>(this.apiUrl, data);
  }
updateStudent(student : Student){
  return this.http.put(`${this.apiUrl}/${student.id}`, student)
}

  deleteStudent(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}

