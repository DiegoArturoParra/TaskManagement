export interface TaskDto {
  TaskId: string;
  TaskName: string;
  Description: string;
  IsCompleted: boolean;
  TextCompleted: string;
}
export interface TaskDetailDto {
  TaskId: string;
  Description: string;
  IsCompleted: boolean;
  DateCreatedString: string;
  DateUpdatedString: string;
}

