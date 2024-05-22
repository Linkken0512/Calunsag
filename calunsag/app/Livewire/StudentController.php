<?php

namespace App\Livewire;

use Livewire\Component;
use App\Models\StudentModel;
use Illustrate\Support\Facades\DB;

class StudentController extends Component
{
    public function render()
    {
        $studentInfo = StudentModel::all();
        return view('livewire.student-controller', compact('studentInfo'))
        ->extends('layouts.app');
    }
}
