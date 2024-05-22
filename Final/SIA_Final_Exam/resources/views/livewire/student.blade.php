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
                    <button wire:click="add">ADD STUDENT</button>
                </div>
                
                <table>
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
                                <button wire:click="edit({{$get->student_id}})">EDIT</button>
                                <button wire:click="delete({{$get->student_id}})">DELETE</button>
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
