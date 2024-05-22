<div class="fixed z-10 inset-0 overflow-y-auto ease-out duration-400">
    <div class="flex items-end justify-center min-h-screen pt-4 px-4 pb-20 text-center sm:block sm:p-0">
        
        <div class="fixed inset-0 transition-opacity">
            <div class="absolute inset-0 bg-gray-500 opacity-75"></div>
        </div>
        
        <!-- This element is to trick the browser into centering the modal contents. -->
        <span class="hidden sm:inline-block sm:align-middle sm:h-screen"></span>
    
        <div class="inline-block align-bottom bg-white rounded-lg text-left overflow-hidden shadow-xl transform transition-all sm:my-8 sm:align-middle sm:max-w-lg sm:w-full" role="dialog" aria-modal="true" aria-labelledby="modal-headline">
            <form class="forms-sample material-form bordered">

                <div class="bg-white px-4 pt-5 pb-4 sm:p-6 sm:pb-4">

                    {{-- start here --}}
                   
                        <h1> 
                            Student Management System
                        </h1> 
                    
                        <div class="form-group">                            
                            <input wire:model="last_name" type="text" > 
                            @error('last_name') <span class="text-danger">{{ $message }}</span> @enderror                           
                            <label for="input" class="control-label">Last Name</label><i class="bar"></i>
                        </div>

                        <div class="form-group">                            
                            <input wire:model="first_name" type="text" >         
                            @error('first_name') <span class="text-danger">{{ $message }}</span> @enderror                   
                            <label for="input" class="control-label">First Name</label><i class="bar"></i>
                        </div>
                        
                        <div class="form-group">
                            <input wire:model="middle_name" type="text" >
                            <label for="input" class="control-label">Middle Name</label><i class="bar"></i>
                        </div>
                        
                        <button wire:click.prevent="save()"><i class="fa fa-floppy-o"></i>Save</button>
                        <button><i class="fa fa-times"></i>Close</button>
                    </div> 
                    
                    {{-- end here --}}


                </div>
            </form>
        </div>
    </div>
</div>
