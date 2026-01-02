export interface TaskItemDto {
  id: number;
  title: string;
  description?: string;  // optional
  isCompleted: boolean;
  createdAt?: string;    // optional, backend can provide timestamp
}
