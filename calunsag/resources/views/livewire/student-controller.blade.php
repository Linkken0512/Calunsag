<div>

<table>
    <thead>
        <tr>
            <th>
                First Name 
            </th>
            <th>
                Middle Name 
            </th>
            <th>
                Last Name 
            </th>
            <th>
                Action 
            </th>
        </tr>
    </thead>
    <tbody> @foreach($studentInfo as $studInfo)
        <tr>
            <td>
                {{$studInfo->first_name}}
            </td>
            <td>
                {{$studInfo->mid_name}}
            </td>
            <td>
                {{$studInfo->last_name}}
            </td>
            <td>
                <button>Edit</button>
                <button>Delete</button>
            </td>
        </tr> @endforeach
    </tbody>
</table>

</div>


