<?php
namespace App\Model\Table;

use Cake\ORM\Query;
use Cake\ORM\RulesChecker;
use Cake\ORM\Table;
use Cake\Validation\Validator;

/**
 * Rollballranking Model
 *
 * @method \App\Model\Entity\Rollballranking get($primaryKey, $options = [])
 * @method \App\Model\Entity\Rollballranking newEntity($data = null, array $options = [])
 * @method \App\Model\Entity\Rollballranking[] newEntities(array $data, array $options = [])
 * @method \App\Model\Entity\Rollballranking|bool save(\Cake\Datasource\EntityInterface $entity, $options = [])
 * @method \App\Model\Entity\Rollballranking|bool saveOrFail(\Cake\Datasource\EntityInterface $entity, $options = [])
 * @method \App\Model\Entity\Rollballranking patchEntity(\Cake\Datasource\EntityInterface $entity, array $data, array $options = [])
 * @method \App\Model\Entity\Rollballranking[] patchEntities($entities, array $data, array $options = [])
 * @method \App\Model\Entity\Rollballranking findOrCreate($search, callable $callback = null, $options = [])
 */
class RollballrankingTable extends Table
{

    /**
     * Initialize method
     *
     * @param array $config The configuration for the Table.
     * @return void
     */
    public function initialize(array $config)
    {
        parent::initialize($config);

        $this->setTable('rollballranking');
        $this->setDisplayField('Rank');
        $this->setPrimaryKey('Rank');
    }

    /**
     * Default validation rules.
     *
     * @param \Cake\Validation\Validator $validator Validator instance.
     * @return \Cake\Validation\Validator
     */
    public function validationDefault(Validator $validator)
    {
        $validator
            ->integer('Rank')
            ->allowEmpty('Rank', 'create');

        $validator
            ->scalar('Name')
            ->maxLength('Name', 30)
            ->requirePresence('Name', 'create')
            ->notEmpty('Name');

        $validator
            ->scalar('Time')
            ->maxLength('Time', 50)
            ->requirePresence('Time', 'create')
            ->notEmpty('Time');

        return $validator;
    }
}
