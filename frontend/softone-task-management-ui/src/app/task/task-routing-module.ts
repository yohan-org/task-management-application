import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TaskList } from './components/task-list/task-list';
import { TaskForm } from './components/task-form/task-form';

const routes: Routes = [
  {
    path: '',
    component: TaskList,
    children: [
      { path: 'edit/:id', component: TaskForm },
      { path: 'add', component: TaskForm }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TaskRoutingModule { }
