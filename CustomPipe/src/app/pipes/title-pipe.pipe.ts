import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'titlePipe'
})
export class TitlePipePipe implements PipeTransform {
    transform(name: string, gender:string): string {
      if(gender==="Male") return `Mr. ${name}`;
      else if(gender==="Female") return `Miss. ${name}`
      return name;
    }
}
