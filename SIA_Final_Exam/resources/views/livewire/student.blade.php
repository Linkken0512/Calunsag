<div>
    
<br>
    <div class="container-xl">
        <div class="table-responsive">
            <div class="table-wrapper">


                {{-- start here --}}

                <div>
                    <h1>STUDENT MANAGEMENT SYSTEM</h1>
                    <h2>List of Students</h2>
                </div>

                <div>
                    <button wire:click="add" class="btn btn-dark" ><i class="ti-user"></i> ADD STUDENT</button>
                </div>
                <br>
                
                <table class="table table-dark">
                    <thead>
                        <tr>
                            <th>Last Name</th>
                            <th>First Name</th>
                            <th>Middle Name</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    @foreach ($studentInfo as $get)
                    <tbody>
                        <tr>
                            <td>{{$get->last_name}}</td>
                            <td>{{$get->first_name}}</td>
                            <td>{{$get->middle_name}}</td>
                            <td>
                                <button wire:click="edit({{$get->student_id}})" class="btn btn-dark btn-rounded btn-icon"><i class="fa fa-pencil"></i> Edit</button>
                                <button wire:click="delete({{$get->student_id}})" class="btn btn-dark btn-rounded btn-icon"><i class="fa fa-trash-o"></i> Delete</button>
                            </td>
                        </tr> 
                    </tbody>
                    @endforeach
                </table>





                {{-- end here --}}
            </div>
        </div>        
    </div>

    @if($openAddOrEdit)
    @include('livewire.addoredit')
    @endif

    @if($openDelete)
    @include('livewire.delete')
    @endif
</div>
