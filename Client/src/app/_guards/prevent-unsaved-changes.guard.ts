import { CanDeactivateFn } from '@angular/router';
import { MemberEditComponent } from '../interceptors/members/member-edit/member-edit.component'; // Removed unnecessary 'type'

export const preventUnsavedChangesGuard: CanDeactivateFn<MemberEditComponent> = 
  (component: MemberEditComponent) => {
    if (component.editform?.dirty) {
      return confirm('Are you sure you want to continue? Any unsaved changes will be lost.');
    }
    return true;
};
