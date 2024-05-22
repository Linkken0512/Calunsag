<?php

namespace App\Livewire;

use Livewire\Component;
use App\Models\StudentModel;
use Illuminate\Support\Facades\DB;

class Student extends Component
{
    public $openAddOrEdit = false;
    public $openDelete = false;
    public $student_id, $last_name, $first_name, $middle_name;

    public function render()
    {
        $studentInfo = StudentModel::orderBy('last_name')->get();

        
            return view('livewire.student', compact('studentInfo'))
                ->layout('layouts.app');
    }

    public function delete($student_id)
    {
        // 
        $getInfo = StudentModel::findOrFail($student_id);
        $this->student_id = $getInfo->student_id;
        $this->openDelete = true;

    }

    public function yes()
    {
        StudentModel::where('student_id', $this->student_id)->delete();
        $this->openDelete = false;
    }

    public function close()
    {
        $this->openDelete = false;
    }
    public function add()
    {
        $this->openAddOrEdit = true;
    }

    public function save()
    {

        $this->validate([
            'last_name' => 'required',
            'first_name' => 'required',
        ]);

        
        StudentModel::updateOrCreate(['student_id' => $this->student_id], [
            'last_name' => $this->last_name,
            'first_name' => $this->first_name,
            'middle_name' => $this->middle_name,
        ]);

        $this->last_name = '';
        $this->first_name = '';
        $this->middle_name = '';

        $this->openAddOrEdit = false;
    }

    public function edit($student_id)
    {
        $getInfo = StudentModel::findOrFail($student_id);
        $this->student_id = $getInfo->student_id;
        $this->last_name = $getInfo->last_name;
        $this->first_name = $getInfo->first_name;
        $this->middle_name = $getInfo->middle_name;
        $this->openAddOrEdit = true;
    }


}
