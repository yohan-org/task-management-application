import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TaskItemDto } from '../../../shared/models/task-item-dto';
import { TaskService } from '../../services/task.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TaskSortPipe } from '../../../shared/pipes/task-sort.pipe';
import { TaskFilterPipe } from '../../../shared/pipes/task-filter.pipe';
import { SHARED_IMPORTS } from '../../../shared/shared-imports';

@Component({
  selector: 'app-task-list',
  imports: [
    SHARED_IMPORTS,
    TaskSortPipe,
    TaskFilterPipe],
  templateUrl: './task-list.html',
  styleUrl: './task-list.css',
})
export class TaskList {

  tasks: TaskItemDto[] = [];
  filterText = '';
  sortOption: keyof TaskItemDto = 'title';

  constructor(private taskService: TaskService, private router: Router) {
    this.loadTasks();
  }

 loadTasks() {
    this.taskService.getTasks().subscribe({
      next: (data) => this.tasks = data,
      error: (err) => console.error('Failed to load tasks', err)
    });
  }

  editTask(taskId: number) {
    // Navigate to the edit form, or open a side panel
    this.router.navigate(['/tasks/edit', taskId]);
  }

  async deleteTask(taskId: number) {
    if (confirm('Are you sure you want to delete this task?')) {
      await this.taskService.deleteTask(taskId);
      await this.loadTasks(); // refresh list
    }
  }

  async toggleComplete(task: TaskItemDto) {
    task.isCompleted = !task.isCompleted;
    await this.taskService.updateTask(task);
  }
}
