<?php
namespace App\Test\TestCase\Model\Table;

use App\Model\Table\RollballrankingTable;
use Cake\ORM\TableRegistry;
use Cake\TestSuite\TestCase;

/**
 * App\Model\Table\RollballrankingTable Test Case
 */
class RollballrankingTableTest extends TestCase
{

    /**
     * Test subject
     *
     * @var \App\Model\Table\RollballrankingTable
     */
    public $Rollballranking;

    /**
     * Fixtures
     *
     * @var array
     */
    public $fixtures = [
        'app.rollballranking'
    ];

    /**
     * setUp method
     *
     * @return void
     */
    public function setUp()
    {
        parent::setUp();
        $config = TableRegistry::getTableLocator()->exists('Rollballranking') ? [] : ['className' => RollballrankingTable::class];
        $this->Rollballranking = TableRegistry::getTableLocator()->get('Rollballranking', $config);
    }

    /**
     * tearDown method
     *
     * @return void
     */
    public function tearDown()
    {
        unset($this->Rollballranking);

        parent::tearDown();
    }

    /**
     * Test initialize method
     *
     * @return void
     */
    public function testInitialize()
    {
        $this->markTestIncomplete('Not implemented yet.');
    }

    /**
     * Test validationDefault method
     *
     * @return void
     */
    public function testValidationDefault()
    {
        $this->markTestIncomplete('Not implemented yet.');
    }
}
