import { Routes } from '@angular/router';
import { StudentComponent } from './components/student/student.component';

export const routes: Routes = [
     {
        path: "", component: StudentComponent
    },
    {
        path: "student", component: StudentComponent
    }
];
