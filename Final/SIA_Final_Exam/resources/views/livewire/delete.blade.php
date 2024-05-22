<div class="fixed z-10 inset-0 overflow-y-auto ease-out duration-400">
    <div class="flex items-end justify-center min-h-screen pt-4 px-4 pb-20 text-center sm:block sm:p-0">
        
        <div class="fixed inset-0 transition-opacity">
            <div class="absolute inset-0 bg-gray-500 opacity-75"></div>
        </div>
        
        <span class="hidden sm:inline-block sm:align-middle sm:h-screen"></span>
    
        <div class="inline-block align-bottom bg-white rounded-lg text-left overflow-hidden shadow-xl transform transition-all sm:my-8 sm:align-middle sm:max-w-lg sm:w-full" role="dialog" aria-modal="true" aria-labelledby="modal-headline">
            <form class="forms-sample material-form bordered">
                <div class="bg-white px-4 pt-5 pb-4 sm:p-6 sm:pb-4">

                    {{-- start here --}}
                      
                       
                    <div>
                      Sure ka?
                    </div>
                          <div>
                              <button wire:click="close">Cancel</button>
                              <button wire:click.prevent="yes()">Yes</button>
                          </div>

                    {{-- end here --}}
                </div>
            </form>
        </div>
    </div>
</div>



