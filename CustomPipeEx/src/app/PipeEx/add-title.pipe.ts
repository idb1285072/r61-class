import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'addTitle',
  standalone:true
})
export class AddTitlePipe implements PipeTransform {

  transform(value: string, gender: string): string {
    if(gender==="Male")
    {
      return "Mr. "+ value;
    }
    if(gender==="Female")
      {
        return "Miss. "+ value;
      }
      return value;
  }

}
