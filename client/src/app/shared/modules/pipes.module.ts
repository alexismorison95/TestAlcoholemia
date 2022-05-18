import { NgModule } from '@angular/core';

import { BooleanPipe } from "../pipes/boolean.pipe";

@NgModule({
    imports: [ ],
    declarations: [ BooleanPipe ],
    exports: [ BooleanPipe ]
})
export class PipesModule {}