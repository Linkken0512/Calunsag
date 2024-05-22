<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class StudentModel extends Model
{
    use HasFactory;
    protected $table = 'student';
    protected $primaryKey = 'student_id';
    protected $fillable = ['last_name', 'first_name', 'middle_name'];
}
