import { Component } from '@angular/core';
import { TaskItemDto } from '../../../shared/models/task-item-dto';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from '../../services/task.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SHARED_IMPORTS } from '../../../shared/shared-imports';

@Component({
  selector: 'app-task-form',
  imports: [ 
    SHARED_IMPORTS
  ],
  templateUrl: './task-form.html',
  styleUrl: './task-form.css',
})
export class TaskForm {
 
  task: TaskItemDto = { id: 0, title: '', description: '', isCompleted: false };

  isEditMode = false;
  successMessage = '';
  errorMessage = '';

  constructor(
    private taskService: TaskService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    const taskId = this.route.snapshot.params['id'];
    if (taskId) {
      this.isEditMode = true;
      this.taskService.getTasks().subscribe(tasks => {
        const t = tasks.find(x => x.id === +taskId);
        if (t) this.task = { ...t };
      });
    }
  }

  onSubmit() {
    if (this.isEditMode) {
      this.taskService.updateTask(this.task).subscribe({
        next: () => (this.successMessage = 'Task updated successfully!'),
        error: () => (this.errorMessage = 'Error updating task')
      });
    } else {
      this.taskService.addTask(this.task).subscribe({
        next: t => {
          this.successMessage = 'Task added successfully!';
          this.task = { id: 0, title: '', description: '', isCompleted: false };
        },
        error: () => (this.errorMessage = 'Error adding task')
      });
    }
  }

  cancel() {
    this.router.navigate(['/tasks']);
  }
}
